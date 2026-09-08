using DoceCantinho.Infrastructure.Context;
using DoceCantinho.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DoceCantinho.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly DoceCantinhoDbContext _db;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(DoceCantinhoDbContext db, ILogger<OrdersController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public class OrderItemDto
        {
            public int DoceId { get; set; }
            public string Nome { get; set; } = string.Empty;
            public decimal Preco { get; set; }
            public int Quantidade { get; set; }
        }

        public class CreateOrderDto
        {
            public string NomeCliente { get; set; } = string.Empty;
            public string Telefone { get; set; } = string.Empty;
            public string? Endereco { get; set; }
            public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NomeCliente) || string.IsNullOrWhiteSpace(dto.Telefone) || dto.Items == null || !dto.Items.Any())
                return BadRequest("Nome, telefone e items são obrigatórios.");

            var pedido = new Pedido
            {
                NomeCliente = dto.NomeCliente,
                Telefone = dto.Telefone,
                Endereco = dto.Endereco,
                Status = "Pendente",
                CreatedAt = DateTime.UtcNow
            };

            decimal total = 0m;
            foreach (var it in dto.Items)
            {
                var pi = new PedidoItem
                {
                    DoceId = it.DoceId,
                    Nome = it.Nome,
                    Preco = it.Preco,
                    Quantidade = it.Quantidade
                };
                pedido.Items.Add(pi);
                total += pi.Subtotal;
            }

            pedido.Total = total;

            _db.Pedidos.Add(pedido);
            _db.SaveChanges();

            // Retorna o caminho da página de pagamento da UI (relativo)
            var paymentPath = $"/Carrinho/Payment?orderId={pedido.Id}";

            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, new { orderId = pedido.Id, paymentPath });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var p = _db.Pedidos.Where(x => x.Id == id).Select(x => new
            {
                x.Id,
                x.NomeCliente,
                x.Telefone,
                x.Endereco,
                x.Total,
                x.PaymentMethod,
                x.Status,
                Items = x.Items.Select(i => new { i.Nome, i.Preco, i.Quantidade, i.Subtotal })
            }).FirstOrDefault();

            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpPost("{id}/pay")]
        public IActionResult Pay(int id, [FromBody] Dictionary<string,string> payload)
        {
            var order = _db.Pedidos.FirstOrDefault(p => p.Id == id);
            if (order == null) return NotFound();

            var method = payload.TryGetValue("paymentMethod", out var pm) ? pm : null;
            if (string.IsNullOrEmpty(method)) return BadRequest("paymentMethod é obrigatório");

            order.PaymentMethod = method;
            order.Status = "Pago";
            _db.SaveChanges();

            return Ok(new { orderId = order.Id, status = order.Status });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var p = _db.Pedidos.Select(x => new
            {
                x.Id,
                x.NomeCliente,
                x.Telefone,
                x.Total,
                x.PaymentMethod,
                x.Status,
                x.CreatedAt,
                ItemsCount = x.Items.Count
            }).ToList();

            return Ok(p);
        }

        public class BatchStatusDto
        {
            public List<int> Ids { get; set; } = new List<int>();
            public string Status { get; set; } = string.Empty;
        }

        [HttpPut("batch-status")]
        public IActionResult UpdateBatchStatus([FromBody] BatchStatusDto dto)
        {
            if (dto.Ids == null || !dto.Ids.Any() || string.IsNullOrWhiteSpace(dto.Status))
                return BadRequest("Ids e Status são obrigatórios.");

            var pedidos = _db.Pedidos.Where(p => dto.Ids.Contains(p.Id)).ToList();
            foreach (var p in pedidos)
            {
                p.Status = dto.Status;
            }
            _db.SaveChanges();

            return Ok(new { message = $"{pedidos.Count} pedidos atualizados com sucesso." });
        }
    }
}
