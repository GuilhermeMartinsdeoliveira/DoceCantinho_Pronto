using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using DoceCantinho.Domain.Entities;
using DoceCantinho.Domain.Interfaces;
using DoceCantinho.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

[Authorize]
public class CarrinhoController : Controller
{
    private const string CARRINHO_SESSION_KEY = "Carrinho";
    private const string CEP_ORIGEM_LOJA = "01001000";
    private readonly IDoceService _doceService;
    private readonly ICheckoutProfileService _checkoutProfileService;
    private readonly IShippingService _shippingService;
    private readonly ICartRepository _cartRepository;
    private readonly DoceCantinho.Infrastructure.Context.DoceCantinhoDbContext _db;

    public CarrinhoController(
        IDoceService doceService,
        ICheckoutProfileService checkoutProfileService,
        IShippingService shippingService,
        ICartRepository cartRepository,
        DoceCantinho.Infrastructure.Context.DoceCantinhoDbContext db)
    {
        _doceService = doceService;
        _checkoutProfileService = checkoutProfileService;
        _shippingService = shippingService;
        _cartRepository = cartRepository;
        _db = db;
    }

    // GET: Carrinho (exibir carrinho)
    public async Task<IActionResult> Index()
    {
        var carrinho = ObterCarrinhoDaSessao();
        var isAuthenticated = User?.Identity?.IsAuthenticated == true;
        CheckoutProfileDto? checkoutProfile = null;
        ShippingQuoteDto? shippingQuote = null;

        if (isAuthenticated)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrWhiteSpace(userId))
            {
                checkoutProfile = await _checkoutProfileService.GetByUserIdAsync(userId);
                if (checkoutProfile != null && checkoutProfile.TemEnderecoCompleto)
                {
                    shippingQuote = await _shippingService.CalculateAsync(CEP_ORIGEM_LOJA, checkoutProfile.Cep);
                }
            }
        }

        var recommendedProducts = await _doceService.GetRecommendedAsync(3);

        var viewModel = new CarrinhoCheckoutViewModel
        {
            Carrinho = carrinho,
            CheckoutProfile = checkoutProfile,
            ShippingQuote = shippingQuote,
            RecommendedProducts = recommendedProducts,
            IsAuthenticated = isAuthenticated,
            NomeCliente = checkoutProfile?.Email ?? string.Empty,
            Cep = checkoutProfile?.Cep ?? string.Empty,
            Logradouro = checkoutProfile?.Logradouro ?? string.Empty,
            Numero = checkoutProfile?.Numero ?? string.Empty,
            Bairro = checkoutProfile?.Bairro ?? string.Empty,
            Cidade = checkoutProfile?.Cidade ?? string.Empty,
            Estado = checkoutProfile?.Estado ?? string.Empty
        };

        return View(viewModel);
    }

    // POST: Adicionar item ao carrinho
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Adicionar(int id, int quantidade = 1)
    {
        var doce = await _doceService.GetByIdAsync(id);
        if (doce == null)
            return NotFound();

        var carrinho = ObterCarrinhoDaSessao();

        // Procura se o item já existe no carrinho
        var itemExistente = carrinho.Itens.FirstOrDefault(i => i.DoceId == id);

        if (itemExistente != null)
        {
            // Se existe, aumenta a quantidade
            itemExistente.Quantidade += quantidade;
        }
        else
        {
            // Cria um novo item no carrinho
            carrinho.Itens.Add(new ItemCarrinho
            {
                DoceId = doce.Id,
                Nome = doce.Title,
                Preco = decimal.Parse(doce.Preco.ToString()),
                Quantidade = quantidade,
                CoverImageUrl = doce.CoverImageUrl
            });
        }

        await SalvarCarrinhemaSessao(carrinho);

        // Redireciona para o carrinho ou volta à página anterior
        return RedirectToAction("Index");
    }

    // POST: Remover item do carrinho
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remover(int doceId)
    {
        var carrinho = ObterCarrinhoDaSessao();
        var item = carrinho.Itens.FirstOrDefault(i => i.DoceId == doceId);

        if (item != null)
        {
            carrinho.Itens.Remove(item);
            // salvar de forma síncrona na sessão e tentar persistir em background
            _ = SalvarCarrinhemaSessao(carrinho);
        }

        return RedirectToAction("Index");
    }

    // POST: Atualizar quantidade
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AtualizarQuantidade(int doceId, int quantidade)
    {
        if (quantidade <= 0)
            return Remover(doceId);

        var carrinho = ObterCarrinhoDaSessao();
        var item = carrinho.Itens.FirstOrDefault(i => i.DoceId == doceId);

        if (item != null)
        {
            item.Quantidade = quantidade;
            _ = SalvarCarrinhemaSessao(carrinho);
        }

        return RedirectToAction("Index");
    }

    // POST: Limpar carrinho
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Limpar()
    {
        HttpContext.Session.Remove(CARRINHO_SESSION_KEY);
        if (User?.Identity != null && User.Identity.IsAuthenticated)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                _ = _cartRepository.DeleteCartByUserIdAsync(userId);
            }
        }
        return RedirectToAction("Index");
    }

    // POST: Finalizar compra
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> FinalizarCompra(
        string nomeCliente,
        string telefone,
        string? cep,
        string? logradouro,
        string? numero,
        string? bairro,
        string? cidade,
        string? estado,
        string? paymentMethod = null)
    {
        var carrinho = ObterCarrinhoDaSessao();

        if (!carrinho.Itens.Any())
            return RedirectToAction("Index");

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        CheckoutProfileDto? checkoutProfile = null;
        if (User?.Identity?.IsAuthenticated == true && !string.IsNullOrWhiteSpace(userId))
        {
            checkoutProfile = await _checkoutProfileService.GetByUserIdAsync(userId);
        }

        nomeCliente = string.IsNullOrWhiteSpace(nomeCliente)
            ? checkoutProfile?.Email ?? nomeCliente
            : nomeCliente;

        var cepFinal = NormalizeCep(cep ?? checkoutProfile?.Cep);
        var logradouroFinal = string.IsNullOrWhiteSpace(logradouro) ? checkoutProfile?.Logradouro : logradouro;
        var numeroFinal = string.IsNullOrWhiteSpace(numero) ? checkoutProfile?.Numero : numero;
        var bairroFinal = string.IsNullOrWhiteSpace(bairro) ? checkoutProfile?.Bairro : bairro;
        var cidadeFinal = string.IsNullOrWhiteSpace(cidade) ? checkoutProfile?.Cidade : cidade;
        var estadoFinal = string.IsNullOrWhiteSpace(estado) ? checkoutProfile?.Estado : estado;

        var endereco = MontarEndereco(logradouroFinal, numeroFinal, bairroFinal, cidadeFinal, estadoFinal, cepFinal);

        if (string.IsNullOrWhiteSpace(nomeCliente) || string.IsNullOrWhiteSpace(telefone))
            return BadRequest("Nome e telefone são obrigatórios");

        ShippingQuoteDto? shippingQuote = null;
        if (!string.IsNullOrWhiteSpace(cepFinal))
        {
            try
            {
                shippingQuote = await _shippingService.CalculateAsync(CEP_ORIGEM_LOJA, cepFinal);
            }
            catch
            {
                shippingQuote = null;
            }
        }

        var mensagem = new StringBuilder();
        mensagem.AppendLine("🎉 *NOVO PEDIDO - Doce Cantinho* 🎉");
        mensagem.AppendLine("━━━━━━━━━━━━━━━━━━━━━━");
        mensagem.AppendLine($"📝 *Cliente:* {nomeCliente}");
        mensagem.AppendLine($"📱 *Telefone:* {telefone}");

        if (!string.IsNullOrWhiteSpace(endereco))
        {
            mensagem.AppendLine($"📍 *Endereço:* {endereco}");
        }

        if (shippingQuote != null)
        {
            mensagem.AppendLine($"🚚 *Frete:* R$ {shippingQuote.ShippingPrice:F2} ({shippingQuote.EstimatedDays} dias)");
        }

        mensagem.AppendLine("━━━━━━━━━━━━━━━━━━━━━━");
        mensagem.AppendLine("🛒 *Itens do Pedido:*");
        mensagem.AppendLine("");

        decimal total = 0;

        foreach (var item in carrinho.Itens)
        {
            var subtotal = item.Preco * item.Quantidade;
            mensagem.AppendLine($"✓ {item.Nome}");
            mensagem.AppendLine($"  Qtd: {item.Quantidade} x R$ {item.Preco:F2}");
            mensagem.AppendLine($"  Subtotal: R$ {subtotal:F2}");
            mensagem.AppendLine("");

            total += subtotal;
        }

        if (shippingQuote != null)
        {
            total += shippingQuote.ShippingPrice;
        }

        mensagem.AppendLine("━━━━━━━━━━━━━━━━━━━━━━");
        mensagem.AppendLine($"💰 *TOTAL:* R$ {total:F2}");
        mensagem.AppendLine("━━━━━━━━━━━━━━━━━━━━━━");
        mensagem.AppendLine("");
        mensagem.AppendLine("Obrigado por sua compra! 🙏");

        // Salvar pedido no banco
        var pedido = new DoceCantinho.Domain.Entities.Pedido
        {
            NomeCliente = nomeCliente,
            Telefone = telefone,
            Endereco = endereco,
            Total = total,
            CreatedAt = DateTime.UtcNow,
            UserId = userId ?? string.Empty,
            Status = string.IsNullOrEmpty(paymentMethod) ? "Pendente" : "Pago",
            PaymentMethod = paymentMethod ?? string.Empty
        };

        foreach (var item in carrinho.Itens)
        {
            pedido.Items.Add(new DoceCantinho.Domain.Entities.PedidoItem
            {
                DoceId = item.DoceId,
                Nome = item.Nome,
                Preco = item.Preco,
                Quantidade = item.Quantidade
            });
        }

        _db.Pedidos.Add(pedido);
        _db.SaveChanges();

        // Limpar sessão após salvar pedido
        HttpContext.Session.Remove(CARRINHO_SESSION_KEY);
        if (User?.Identity != null && User.Identity.IsAuthenticated)
        {
            var cartUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(cartUserId))
            {
                _ = _cartRepository.DeleteCartByUserIdAsync(cartUserId);
            }
        }

        // Se foi selecionado método de pagamento no carrinho, consideramos o pagamento concluído
        if (!string.IsNullOrEmpty(paymentMethod))
        {
            return RedirectToAction("PaymentResult", new { orderId = pedido.Id });
        }

        // Caso contrário, segue para a simulação de pagamento tradicional
        return RedirectToAction("Payment", new { orderId = pedido.Id });
    }

    // POST: Finalizar compra e enviar para WhatsApp (opção direta)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult FinalizarWhatsApp(string nomeCliente, string telefone, string? endereco = null)
    {
        var carrinho = ObterCarrinhoDaSessao();

        if (!carrinho.Itens.Any())
            return RedirectToAction("Index");

        if (string.IsNullOrWhiteSpace(nomeCliente) || string.IsNullOrWhiteSpace(telefone))
            return BadRequest("Nome e telefone são obrigatórios");

        decimal total = 0;
        foreach (var item in carrinho.Itens)
        {
            total += item.Preco * item.Quantidade;
        }

        var pedido = new DoceCantinho.Domain.Entities.Pedido
        {
            NomeCliente = nomeCliente,
            Telefone = telefone,
            Endereco = endereco,
            Total = total,
            CreatedAt = DateTime.UtcNow,
            Status = "Pendente"
        };

        foreach (var item in carrinho.Itens)
        {
            pedido.Items.Add(new DoceCantinho.Domain.Entities.PedidoItem
            {
                DoceId = item.DoceId,
                Nome = item.Nome,
                Preco = item.Preco,
                Quantidade = item.Quantidade
            });
        }

        _db.Pedidos.Add(pedido);
        _db.SaveChanges();

        // Monta mensagem para WhatsApp
        var sb = new StringBuilder();
        sb.AppendLine($"NOVO PEDIDO - Doce Cantinho\n");
        sb.AppendLine($"Cliente: {nomeCliente}");
        sb.AppendLine($"Telefone: {telefone}");
        if (!string.IsNullOrWhiteSpace(endereco)) sb.AppendLine($"Endereço: {endereco}");
        sb.AppendLine("\nItens:");
        foreach (var it in pedido.Items)
        {
            sb.AppendLine($"- {it.Nome} x{it.Quantidade} = R$ {it.Subtotal:F2}");
        }
        sb.AppendLine($"\nTotal: R$ {pedido.Total:F2}");

        // Limpar sessão
        HttpContext.Session.Remove(CARRINHO_SESSION_KEY);

        string numeroWhatsApp = "5511999999999"; // substituir pelo número real
        string link = $"https://wa.me/{numeroWhatsApp}?text={Uri.EscapeDataString(sb.ToString())}";

        return Redirect(link);
    }

    [HttpGet]
    public IActionResult Payment(int orderId)
    {
        var order = _db.Pedidos
            .Where(p => p.Id == orderId)
            .Select(p => new
            {
                p.Id,
                p.NomeCliente,
                p.Telefone,
                p.Endereco,
                p.Total,
                Items = p.Items.Select(i => new { i.Nome, i.Preco, i.Quantidade, i.Subtotal })
            })
            .FirstOrDefault();

        if (order == null) return NotFound();

        ViewData["Order"] = order;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Payment(int orderId, string paymentMethod, string? cardNumber, string? cardName)
    {
        var order = _db.Pedidos.FirstOrDefault(p => p.Id == orderId);
        if (order == null) return NotFound();

        // Simula processamento de pagamento
        // Em ambiente real aqui integraria com gateway de pagamento
        order.PaymentMethod = paymentMethod;
        order.Status = "Pago";
        _db.SaveChanges();

        return RedirectToAction("PaymentResult", new { orderId = order.Id });
    }

    [HttpGet]
    public IActionResult PaymentResult(int orderId)
    {
        var order = _db.Pedidos.FirstOrDefault(p => p.Id == orderId);
        if (order == null) return NotFound();
        return View(order);
    }

    // Métodos auxiliares
    private static string NormalizeCep(string? cep)
        => new string((cep ?? string.Empty).Where(char.IsDigit).ToArray());

    private static string MontarEndereco(string? logradouro, string? numero, string? bairro, string? cidade, string? estado, string? cep)
    {
        var partes = new List<string>();

        if (!string.IsNullOrWhiteSpace(logradouro)) partes.Add(logradouro);
        if (!string.IsNullOrWhiteSpace(numero) && partes.Count > 0) partes[partes.Count - 1] = $"{partes.Last()}, {numero}";
        if (!string.IsNullOrWhiteSpace(numero) && partes.Count == 0) partes.Add(numero);
        if (!string.IsNullOrWhiteSpace(bairro)) partes.Add(bairro);
        if (!string.IsNullOrWhiteSpace(cidade)) partes.Add(cidade);
        if (!string.IsNullOrWhiteSpace(estado)) partes.Add(estado);
        if (!string.IsNullOrWhiteSpace(cep)) partes.Add($"CEP {cep}");

        return string.Join(" - ", partes.Where(p => !string.IsNullOrWhiteSpace(p)));
    }

    private CarrinhoSessao ObterCarrinhoDaSessao()
    {
        var carrinhoJson = HttpContext.Session.GetString(CARRINHO_SESSION_KEY);

        if (string.IsNullOrEmpty(carrinhoJson))
        {
            // se usuário autenticado, tentar carregar do DB
            if (User?.Identity != null && User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(userId))
                {
                    var persisted = _cartRepository.GetCartJsonByUserIdAsync(userId).GetAwaiter().GetResult();
                    if (!string.IsNullOrEmpty(persisted))
                    {
                        HttpContext.Session.SetString(CARRINHO_SESSION_KEY, persisted);
                        return JsonSerializer.Deserialize<CarrinhoSessao>(persisted) ?? new CarrinhoSessao { Itens = new List<ItemCarrinho>() };
                    }
                }
            }

            return new CarrinhoSessao { Itens = new List<ItemCarrinho>() };
        }

        return JsonSerializer.Deserialize<CarrinhoSessao>(carrinhoJson) 
            ?? new CarrinhoSessao { Itens = new List<ItemCarrinho>() };
    }

    private async Task SalvarCarrinhemaSessao(CarrinhoSessao carrinho)
    {
        var carrinhoJson = JsonSerializer.Serialize(carrinho);
        HttpContext.Session.SetString(CARRINHO_SESSION_KEY, carrinhoJson);

        if (User?.Identity != null && User.Identity.IsAuthenticated)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                await _cartRepository.SaveCartJsonByUserIdAsync(userId, carrinhoJson);
            }
        }
    }

    [HttpGet]
    public IActionResult Quantidade()
    {
        var carrinho = ObterCarrinhoDaSessao();
        return Json(new { count = carrinho.QuantidadeTotal });
    }
}

// Modelos para carrinho
public class CarrinhoSessao
{
    public List<ItemCarrinho> Itens { get; set; } = new();

    public decimal Total => Itens.Sum(i => i.Preco * i.Quantidade);
    public int QuantidadeTotal => Itens.Sum(i => i.Quantidade);
}

public class ItemCarrinho
{
    public int DoceId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public string? CoverImageUrl { get; set; }
}
