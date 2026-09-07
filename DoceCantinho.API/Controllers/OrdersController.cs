using DoceCantinho.Infrastructure.Context;
using DoceCantinho.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DoceCantinho.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly DoceCantinhoDbContext _db;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(
            DoceCantinhoDbContext db,
            ILogger<OrdersController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // ============================================================
        // DTO - ATUALIZAÇÃO DE PEDIDO
        // ============================================================

        public class UpdateOrderDto
        {
            public string NomeCliente { get; set; } = string.Empty;

            public string Telefone { get; set; } = string.Empty;

            public string? Endereco { get; set; }

            public List<UpdateOrderItemDto> Items { get; set; } = new();
        }

        public class UpdateOrderItemDto
        {
            public int DoceId { get; set; }

            public string Nome { get; set; } = string.Empty;

            public decimal Preco { get; set; }

            public int Quantidade { get; set; }
        }

        // ============================================================
        // DTO - ITEM DO PEDIDO
        // ============================================================

        public class OrderItemDto
        {
            public int DoceId { get; set; }

            public string Nome { get; set; } = string.Empty;

            public decimal Preco { get; set; }

            public int Quantidade { get; set; }
        }

        // ============================================================
        // DTO - CRIAÇÃO DE PEDIDO
        // ============================================================

        public class CreateOrderDto
        {
            public string NomeCliente { get; set; } = string.Empty;

            public string Telefone { get; set; } = string.Empty;

            public string? Endereco { get; set; }

            public List<OrderItemDto> Items { get; set; } = new();
        }

        // ============================================================
        // CRIAR PEDIDO
        // POST: /api/orders
        // ============================================================

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Dados do pedido não informados.");
            }

            if (string.IsNullOrWhiteSpace(dto.NomeCliente))
            {
                return BadRequest("Nome, telefone e items são obrigatórios.");
            }

            if (string.IsNullOrWhiteSpace(dto.Telefone))
            {
                return BadRequest("Nome, telefone e items são obrigatórios.");
            }

            if (dto.Items == null || !dto.Items.Any())
            {
                return BadRequest("Nome, telefone e items são obrigatórios.");
            }

            try
            {
                var pedido = new Pedido
                {
                    NomeCliente = dto.NomeCliente.Trim(),
                    Telefone = dto.Telefone.Trim(),
                    Endereco = string.IsNullOrWhiteSpace(dto.Endereco)
                        ? null
                        : dto.Endereco.Trim(),
                    Status = "Pendente",
                    CreatedAt = DateTime.UtcNow
                };

                decimal total = 0m;

                foreach (var it in dto.Items)
                {
                    if (it.DoceId <= 0)
                    {
                        return BadRequest("Produto inválido.");
                    }

                    if (it.Quantidade <= 0)
                    {
                        return BadRequest(
                            "A quantidade dos produtos deve ser maior que zero.");
                    }

                    var doce = _db.Doces
                        .FirstOrDefault(d => d.Id == it.DoceId);

                    if (doce == null)
                    {
                        return BadRequest(
                            $"O produto \"{it.Nome}\" não foi encontrado.");
                    }

                    if (!doce.IsAtivo)
                    {
                        return BadRequest(
                            $"O produto \"{doce.Title}\" está inativo.");
                    }

                    if (doce.QuantidadeEstoque < it.Quantidade)
                    {
                        return BadRequest(
                            $"Estoque insuficiente para \"{doce.Title}\". " +
                            $"Disponível: {doce.QuantidadeEstoque}.");
                    }

                    decimal preco = (decimal)doce.Preco;

                    var pi = new PedidoItem
                    {
                        DoceId = doce.Id,
                        Nome = doce.Title,
                        Preco = preco,
                        Quantidade = it.Quantidade
                    };

                    pedido.Items.Add(pi);

                    total += pi.Subtotal;
                }

                pedido.Total = total;

                _db.Pedidos.Add(pedido);
                _db.SaveChanges();

                // Retorna o caminho da página de pagamento da UI
                var paymentPath =
                    $"/Carrinho/Payment?orderId={pedido.Id}";

                return CreatedAtAction(
                    nameof(Get),
                    new { id = pedido.Id },
                    new
                    {
                        orderId = pedido.Id,
                        paymentPath
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao criar pedido.");

                return StatusCode(
                    500,
                    new
                    {
                        message = "Ocorreu um erro ao criar o pedido."
                    });
            }
        }

        // ============================================================
        // OBTER PEDIDO POR ID
        // GET: /api/orders/{id}
        // ============================================================

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var p = _db.Pedidos
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.NomeCliente,
                    x.Telefone,
                    x.Endereco,
                    x.Total,
                    x.PaymentMethod,
                    x.Status,

                    Items = x.Items.Select(i => new
                    {
                        i.Id,
                        i.DoceId,
                        i.Nome,
                        i.Preco,
                        i.Quantidade,
                        i.Subtotal
                    })
                })
                .FirstOrDefault();

            if (p == null)
            {
                return NotFound(
                    new
                    {
                        message = "Pedido não encontrado."
                    });
            }

            return Ok(p);
        }

        // ============================================================
        // EDITAR PEDIDO
        // PUT: /api/orders/{id}
        // ============================================================

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateOrderDto dto)
        {
            if (dto == null)
            {
                return BadRequest(
                    new
                    {
                        message = "Dados do pedido não informados."
                    });
            }

            if (string.IsNullOrWhiteSpace(dto.NomeCliente))
            {
                return BadRequest(
                    new
                    {
                        message = "O nome do cliente é obrigatório."
                    });
            }

            if (string.IsNullOrWhiteSpace(dto.Telefone))
            {
                return BadRequest(
                    new
                    {
                        message = "O telefone do cliente é obrigatório."
                    });
            }

            if (dto.Items == null || dto.Items.Count == 0)
            {
                return BadRequest(
                    new
                    {
                        message =
                            "O pedido precisa possuir pelo menos um produto."
                    });
            }

            var pedido = await _db.Pedidos
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
            {
                return NotFound(
                    new
                    {
                        message = "Pedido não encontrado."
                    });
            }

            try
            {
                // --------------------------------------------------------
                // DADOS PRINCIPAIS
                // --------------------------------------------------------

                pedido.NomeCliente = dto.NomeCliente.Trim();

                pedido.Telefone = dto.Telefone.Trim();

                pedido.Endereco =
                    string.IsNullOrWhiteSpace(dto.Endereco)
                        ? null
                        : dto.Endereco.Trim();

                // --------------------------------------------------------
                // REMOVER ITENS ANTIGOS
                // --------------------------------------------------------

                if (pedido.Items.Count > 0)
                {
                    _db.PedidoItems.RemoveRange(pedido.Items);
                }

                pedido.Items.Clear();

                // --------------------------------------------------------
                // ADICIONAR ITENS NOVOS
                // --------------------------------------------------------

                decimal total = 0m;

                foreach (var itemDto in dto.Items)
                {
                    if (itemDto.DoceId <= 0)
                    {
                        return BadRequest(
                            new
                            {
                                message =
                                    "Um dos produtos do pedido é inválido."
                            });
                    }

                    if (itemDto.Quantidade <= 0)
                    {
                        return BadRequest(
                            new
                            {
                                message =
                                    "A quantidade dos produtos deve ser maior que zero."
                            });
                    }

                    // Busca o produto diretamente no banco.
                    var doce = await _db.Doces
                        .FirstOrDefaultAsync(
                            d => d.Id == itemDto.DoceId);

                    if (doce == null)
                    {
                        return BadRequest(
                            new
                            {
                                message =
                                    $"O produto \"{itemDto.Nome}\" não foi encontrado."
                            });
                    }

                    // Verifica se o produto está ativo.
                    if (!doce.IsAtivo)
                    {
                        return BadRequest(
                            new
                            {
                                message =
                                    $"O produto \"{doce.Title}\" está inativo."
                            });
                    }

                    // Verifica o estoque.
                    if (doce.QuantidadeEstoque < itemDto.Quantidade)
                    {
                        return BadRequest(
                            new
                            {
                                message =
                                    $"Estoque insuficiente para " +
                                    $"\"{doce.Title}\". " +
                                    $"Disponível: " +
                                    $"{doce.QuantidadeEstoque}."
                            });
                    }

                    // O preço usado é sempre o preço atual
                    // cadastrado no banco.
                    decimal preco = (decimal)doce.Preco;

                    var novoItem = new PedidoItem
                    {
                        PedidoId = pedido.Id,
                        DoceId = doce.Id,
                        Nome = doce.Title,
                        Preco = preco,
                        Quantidade = itemDto.Quantidade
                    };

                    pedido.Items.Add(novoItem);

                    total += preco * itemDto.Quantidade;
                }

                // --------------------------------------------------------
                // ATUALIZAR TOTAL
                // --------------------------------------------------------

                pedido.Total = total;

                // --------------------------------------------------------
                // SALVAR
                // --------------------------------------------------------

                await _db.SaveChangesAsync();

                return Ok(
                    new
                    {
                        message = "Pedido atualizado com sucesso.",
                        orderId = pedido.Id
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao atualizar o pedido {PedidoId}.",
                    id);

                return StatusCode(
                    500,
                    new
                    {
                        message =
                            "Ocorreu um erro ao atualizar o pedido."
                    });
            }
        }

        // ============================================================
        // EXCLUIR PEDIDO
        // DELETE: /api/orders/{id}
        // ============================================================

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await _db.Pedidos
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
            {
                return NotFound(
                    new
                    {
                        message = "Pedido não encontrado."
                    });
            }

            try
            {
                // --------------------------------------------------------
                // PRIMEIRO REMOVE OS ITENS
                // --------------------------------------------------------

                if (pedido.Items.Count > 0)
                {
                    _db.PedidoItems.RemoveRange(pedido.Items);
                }

                // --------------------------------------------------------
                // DEPOIS REMOVE O PEDIDO
                // --------------------------------------------------------

                _db.Pedidos.Remove(pedido);

                await _db.SaveChangesAsync();

                return Ok(
                    new
                    {
                        message = "Pedido excluído com sucesso.",
                        orderId = id
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao excluir o pedido {PedidoId}.",
                    id);

                return StatusCode(
                    500,
                    new
                    {
                        message =
                            "Ocorreu um erro ao excluir o pedido."
                    });
            }
        }

        // ============================================================
        // PAGAR PEDIDO
        // POST: /api/orders/{id}/pay
        // ============================================================

        [HttpPost("{id}/pay")]
        public IActionResult Pay(
            int id,
            [FromBody] Dictionary<string, string> payload)
        {
            var order = _db.Pedidos
                .FirstOrDefault(p => p.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            var method =
                payload.TryGetValue(
                    "paymentMethod",
                    out var pm)
                    ? pm
                    : null;

            if (string.IsNullOrEmpty(method))
            {
                return BadRequest(
                    "paymentMethod é obrigatório");
            }

            order.PaymentMethod = method;
            order.Status = "Pago";

            _db.SaveChanges();

            return Ok(
                new
                {
                    orderId = order.Id,
                    status = order.Status
                });
        }

        // ============================================================
        // LISTAR TODOS OS PEDIDOS
        // GET: /api/orders
        // ============================================================

        [HttpGet]
        public IActionResult GetAll()
        {
            var p = _db.Pedidos
                .Select(x => new
                {
                    x.Id,
                    x.NomeCliente,
                    x.Telefone,
                    x.Total,
                    x.PaymentMethod,
                    x.Status,
                    x.CreatedAt,
                    ItemsCount = x.Items.Count
                })
                .ToList();

            return Ok(p);
        }

        // ============================================================
        // DTO - ATUALIZAÇÃO EM LOTE
        // ============================================================

        public class BatchStatusDto
        {
            public List<int> Ids { get; set; } = new();

            public string Status { get; set; } = string.Empty;
        }

        // ============================================================
        // ATUALIZAR STATUS EM LOTE
        // PUT: /api/orders/batch-status
        // ============================================================

        [HttpPut("batch-status")]
        public IActionResult UpdateBatchStatus(
            [FromBody] BatchStatusDto dto)
        {
            if (dto == null)
            {
                return BadRequest(
                    "Dados não informados.");
            }

            if (dto.Ids == null || !dto.Ids.Any())
            {
                return BadRequest(
                    "Ids e Status são obrigatórios.");
            }

            if (string.IsNullOrWhiteSpace(dto.Status))
            {
                return BadRequest(
                    "Ids e Status são obrigatórios.");
            }

            var pedidos = _db.Pedidos
                .Where(p => dto.Ids.Contains(p.Id))
                .ToList();

            foreach (var p in pedidos)
            {
                p.Status = dto.Status;
            }

            _db.SaveChanges();

            return Ok(
                new
                {
                    message =
                        $"{pedidos.Count} pedidos atualizados com sucesso."
                });
        }
    }
}