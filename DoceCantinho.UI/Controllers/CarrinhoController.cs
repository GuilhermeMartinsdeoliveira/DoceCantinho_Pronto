using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using DoceCantinho.Domain.Entities;
using DoceCantinho.Domain.Interfaces;
using DoceCantinho.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

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

    // =========================================================
    // CARRINHO
    // =========================================================

    [HttpGet]
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
                checkoutProfile =
                    await _checkoutProfileService.GetByUserIdAsync(userId);

                if (checkoutProfile != null &&
                    checkoutProfile.TemEnderecoCompleto)
                {
                    shippingQuote =
                        await _shippingService.CalculateAsync(
                            CEP_ORIGEM_LOJA,
                            checkoutProfile.Cep);
                }
            }
        }

        var recommendedProducts =
            await _doceService.GetRecommendedAsync(3);

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

    // =========================================================
    // ADICIONAR
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Adicionar(
        int id,
        int quantidade = 1)
    {
        var doce = await _doceService.GetByIdAsync(id);

        if (doce == null)
            return NotFound();

        if (quantidade <= 0)
            quantidade = 1;

        var carrinho = ObterCarrinhoDaSessao();

        var itemExistente =
            carrinho.Itens.FirstOrDefault(i => i.DoceId == id);

        if (itemExistente != null)
        {
            itemExistente.Quantidade += quantidade;
        }
        else
        {
            carrinho.Itens.Add(new ItemCarrinho
            {
                DoceId = doce.Id,
                Nome = doce.Title,
                Preco = decimal.Parse(doce.Preco.ToString()),
                Quantidade = quantidade,
                CoverImageUrl = doce.CoverImageUrl
            });
        }

        await SalvarCarrinhoNaSessao(carrinho);

        return RedirectToAction("Index");
    }

    // =========================================================
    // REMOVER
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remover(int doceId)
    {
        var carrinho = ObterCarrinhoDaSessao();

        var item =
            carrinho.Itens.FirstOrDefault(i => i.DoceId == doceId);

        if (item != null)
        {
            carrinho.Itens.Remove(item);
            _ = SalvarCarrinhoNaSessao(carrinho);
        }

        return RedirectToAction("Index");
    }

    // =========================================================
    // ATUALIZAR QUANTIDADE
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AtualizarQuantidade(
        int doceId,
        int quantidade)
    {
        if (quantidade <= 0)
            return Remover(doceId);

        var carrinho = ObterCarrinhoDaSessao();

        var item =
            carrinho.Itens.FirstOrDefault(i => i.DoceId == doceId);

        if (item != null)
        {
            item.Quantidade = quantidade;
            _ = SalvarCarrinhoNaSessao(carrinho);
        }

        return RedirectToAction("Index");
    }

    // =========================================================
    // LIMPAR
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Limpar()
    {
        HttpContext.Session.Remove(CARRINHO_SESSION_KEY);

        if (User?.Identity?.IsAuthenticated == true)
        {
            var userId =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                _ = _cartRepository.DeleteCartByUserIdAsync(userId);
            }
        }

        return RedirectToAction("Index");
    }

    // =========================================================
    // FINALIZAR COMPRA
    // =========================================================

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
        // =====================================================
        // PRIMEIRO: VERIFICA SE ESTÁ LOGADO
        // =====================================================

        if (User?.Identity?.IsAuthenticated != true)
        {
            // Guarda os dados do checkout na sessão
            HttpContext.Session.SetString(
                "CheckoutNome",
                nomeCliente ?? string.Empty);

            HttpContext.Session.SetString(
                "CheckoutTelefone",
                telefone ?? string.Empty);

            HttpContext.Session.SetString(
                "CheckoutCep",
                cep ?? string.Empty);

            HttpContext.Session.SetString(
                "CheckoutLogradouro",
                logradouro ?? string.Empty);

            HttpContext.Session.SetString(
                "CheckoutNumero",
                numero ?? string.Empty);

            HttpContext.Session.SetString(
                "CheckoutBairro",
                bairro ?? string.Empty);

            HttpContext.Session.SetString(
                "CheckoutCidade",
                cidade ?? string.Empty);

            HttpContext.Session.SetString(
                "CheckoutEstado",
                estado ?? string.Empty);

            // Vai para cadastro
            return RedirectToAction(
                "Register",
                "Account",
                new
                {
                    returnUrl = Url.Action(
                        "Index",
                        "Carrinho")
                });
        }

        // =====================================================
        // DAQUI PARA BAIXO, SOMENTE USUÁRIO LOGADO
        // =====================================================

        var carrinho = ObterCarrinhoDaSessao();

        if (!carrinho.Itens.Any())
            return RedirectToAction("Index");

        var userId =
            User.FindFirstValue(ClaimTypes.NameIdentifier);

        CheckoutProfileDto? checkoutProfile = null;

        if (!string.IsNullOrWhiteSpace(userId))
        {
            checkoutProfile =
                await _checkoutProfileService
                    .GetByUserIdAsync(userId);
        }

        nomeCliente = string.IsNullOrWhiteSpace(nomeCliente)
            ? checkoutProfile?.Email ?? string.Empty
            : nomeCliente;

        var cepFinal =
            NormalizeCep(cep ?? checkoutProfile?.Cep);

        var logradouroFinal =
            string.IsNullOrWhiteSpace(logradouro)
                ? checkoutProfile?.Logradouro
                : logradouro;

        var numeroFinal =
            string.IsNullOrWhiteSpace(numero)
                ? checkoutProfile?.Numero
                : numero;

        var bairroFinal =
            string.IsNullOrWhiteSpace(bairro)
                ? checkoutProfile?.Bairro
                : bairro;

        var cidadeFinal =
            string.IsNullOrWhiteSpace(cidade)
                ? checkoutProfile?.Cidade
                : cidade;

        var estadoFinal =
            string.IsNullOrWhiteSpace(estado)
                ? checkoutProfile?.Estado
                : estado;

        var endereco = MontarEndereco(
            logradouroFinal,
            numeroFinal,
            bairroFinal,
            cidadeFinal,
            estadoFinal,
            cepFinal);

        if (string.IsNullOrWhiteSpace(nomeCliente) ||
            string.IsNullOrWhiteSpace(telefone))
        {
            return BadRequest(
                "Nome e telefone são obrigatórios");
        }

        ShippingQuoteDto? shippingQuote = null;

        if (!string.IsNullOrWhiteSpace(cepFinal))
        {
            try
            {
                shippingQuote =
                    await _shippingService.CalculateAsync(
                        CEP_ORIGEM_LOJA,
                        cepFinal);
            }
            catch
            {
                shippingQuote = null;
            }
        }

        // =====================================================
        // CALCULAR TOTAL
        // =====================================================

        decimal total = 0;

        foreach (var item in carrinho.Itens)
        {
            total += item.Preco * item.Quantidade;
        }

        if (shippingQuote != null)
        {
            total += shippingQuote.ShippingPrice;
        }

        // =====================================================
        // CRIAR PEDIDO
        // =====================================================

        var pedido =
            new DoceCantinho.Domain.Entities.Pedido
            {
                NomeCliente = nomeCliente,
                Telefone = telefone,
                Endereco = endereco,
                Total = total,
                CreatedAt = DateTime.UtcNow,
                UserId = userId ?? string.Empty,
                Status = string.IsNullOrEmpty(paymentMethod)
                    ? "Pendente"
                    : "Pago",
                PaymentMethod = paymentMethod ?? string.Empty
            };

        foreach (var item in carrinho.Itens)
        {
            pedido.Items.Add(
                new DoceCantinho.Domain.Entities.PedidoItem
                {
                    DoceId = item.DoceId,
                    Nome = item.Nome,
                    Preco = item.Preco,
                    Quantidade = item.Quantidade
                });
        }

        _db.Pedidos.Add(pedido);
        _db.SaveChanges();

        // =====================================================
        // LIMPAR CARRINHO
        // =====================================================

        HttpContext.Session.Remove(
            CARRINHO_SESSION_KEY);

        if (!string.IsNullOrEmpty(userId))
        {
            _ = _cartRepository
                .DeleteCartByUserIdAsync(userId);
        }

        // =====================================================
        // PAGAMENTO
        // =====================================================

        if (!string.IsNullOrEmpty(paymentMethod))
        {
            return RedirectToAction(
                "PaymentResult",
                new { orderId = pedido.Id });
        }

        return RedirectToAction(
            "Payment",
            new { orderId = pedido.Id });
    }

    // =========================================================
    // WHATSAPP
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult FinalizarWhatsApp(
        string nomeCliente,
        string telefone,
        string? endereco = null)
    {
        var carrinho = ObterCarrinhoDaSessao();

        if (!carrinho.Itens.Any())
            return RedirectToAction("Index");

        if (string.IsNullOrWhiteSpace(nomeCliente) ||
            string.IsNullOrWhiteSpace(telefone))
        {
            return BadRequest(
                "Nome e telefone são obrigatórios");
        }

        decimal total = 0;

        foreach (var item in carrinho.Itens)
        {
            total += item.Preco * item.Quantidade;
        }

        var pedido =
            new DoceCantinho.Domain.Entities.Pedido
            {
                NomeCliente = nomeCliente,
                Telefone = telefone,
                Endereco = endereco,
                Total = total,
                CreatedAt = DateTime.UtcNow,
                Status = "Pendente",
                UserId = User?.Identity?.IsAuthenticated == true
                    ? User.FindFirstValue(
                        ClaimTypes.NameIdentifier) ?? string.Empty
                    : string.Empty
            };

        foreach (var item in carrinho.Itens)
        {
            pedido.Items.Add(
                new DoceCantinho.Domain.Entities.PedidoItem
                {
                    DoceId = item.DoceId,
                    Nome = item.Nome,
                    Preco = item.Preco,
                    Quantidade = item.Quantidade
                });
        }

        _db.Pedidos.Add(pedido);
        _db.SaveChanges();

        var sb = new StringBuilder();

        sb.AppendLine("NOVO PEDIDO - Doce Cantinho");
        sb.AppendLine();
        sb.AppendLine($"Cliente: {nomeCliente}");
        sb.AppendLine($"Telefone: {telefone}");

        if (!string.IsNullOrWhiteSpace(endereco))
            sb.AppendLine($"Endereço: {endereco}");

        sb.AppendLine();
        sb.AppendLine("Itens:");

        foreach (var it in pedido.Items)
        {
            sb.AppendLine(
                $"- {it.Nome} x{it.Quantidade} = R$ {it.Subtotal:F2}");
        }

        sb.AppendLine();
        sb.AppendLine($"Total: R$ {pedido.Total:F2}");

        HttpContext.Session.Remove(
            CARRINHO_SESSION_KEY);

        string numeroWhatsApp = "5511999999999";

        string link =
            $"https://wa.me/{numeroWhatsApp}?text=" +
            Uri.EscapeDataString(sb.ToString());

        return Redirect(link);
    }

    // =========================================================
    // PAGAMENTO
    // =========================================================

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
                Items = p.Items.Select(i => new
                {
                    i.Nome,
                    i.Preco,
                    i.Quantidade,
                    i.Subtotal
                })
            })
            .FirstOrDefault();

        if (order == null)
            return NotFound();

        ViewData["Order"] = order;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Payment(
        int orderId,
        string paymentMethod,
        string? cardNumber,
        string? cardName)
    {
        var order =
            _db.Pedidos.FirstOrDefault(
                p => p.Id == orderId);

        if (order == null)
            return NotFound();

        order.PaymentMethod = paymentMethod;
        order.Status = "Pago";

        _db.SaveChanges();

        return RedirectToAction(
            "PaymentResult",
            new { orderId = order.Id });
    }

    [HttpGet]
    public IActionResult PaymentResult(int orderId)
    {
        var order =
            _db.Pedidos.FirstOrDefault(
                p => p.Id == orderId);

        if (order == null)
            return NotFound();

        return View(order);
    }

    // =========================================================
    // QUANTIDADE DO CARRINHO
    // =========================================================

    [HttpGet]
    public IActionResult Quantidade()
    {
        var carrinho = ObterCarrinhoDaSessao();

        return Json(new
        {
            count = carrinho.QuantidadeTotal
        });
    }

    // =========================================================
    // AUXILIARES
    // =========================================================

    private static string NormalizeCep(string? cep)
    {
        return new string(
            (cep ?? string.Empty)
                .Where(char.IsDigit)
                .ToArray());
    }

    private static string MontarEndereco(
        string? logradouro,
        string? numero,
        string? bairro,
        string? cidade,
        string? estado,
        string? cep)
    {
        var partes = new List<string>();

        if (!string.IsNullOrWhiteSpace(logradouro))
            partes.Add(logradouro);

        if (!string.IsNullOrWhiteSpace(numero) &&
            partes.Count > 0)
        {
            partes[partes.Count - 1] =
                $"{partes.Last()}, {numero}";
        }

        if (!string.IsNullOrWhiteSpace(numero) &&
            partes.Count == 0)
        {
            partes.Add(numero);
        }

        if (!string.IsNullOrWhiteSpace(bairro))
            partes.Add(bairro);

        if (!string.IsNullOrWhiteSpace(cidade))
            partes.Add(cidade);

        if (!string.IsNullOrWhiteSpace(estado))
            partes.Add(estado);

        if (!string.IsNullOrWhiteSpace(cep))
            partes.Add($"CEP {cep}");

        return string.Join(
            " - ",
            partes.Where(
                p => !string.IsNullOrWhiteSpace(p)));
    }

    private CarrinhoSessao ObterCarrinhoDaSessao()
    {
        var carrinhoJson =
            HttpContext.Session.GetString(
                CARRINHO_SESSION_KEY);

        if (string.IsNullOrEmpty(carrinhoJson))
        {
            // Usuário logado:
            // tenta recuperar o carrinho salvo no banco.
            if (User?.Identity?.IsAuthenticated == true)
            {
                var userId =
                    User.FindFirstValue(
                        ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(userId))
                {
                    var persisted =
                        _cartRepository
                            .GetCartJsonByUserIdAsync(userId)
                            .GetAwaiter()
                            .GetResult();

                    if (!string.IsNullOrEmpty(persisted))
                    {
                        HttpContext.Session.SetString(
                            CARRINHO_SESSION_KEY,
                            persisted);

                        return JsonSerializer.Deserialize<CarrinhoSessao>(
                            persisted)
                            ?? new CarrinhoSessao();
                    }
                }
            }

            // Visitante: carrinho vazio na sessão.
            return new CarrinhoSessao();
        }

        return JsonSerializer.Deserialize<CarrinhoSessao>(
            carrinhoJson)
            ?? new CarrinhoSessao();
    }

    private async Task SalvarCarrinhoNaSessao(
        CarrinhoSessao carrinho)
    {
        var carrinhoJson =
            JsonSerializer.Serialize(carrinho);

        // Sempre salva na sessão.
        // Portanto visitante também pode ter carrinho.
        HttpContext.Session.SetString(
            CARRINHO_SESSION_KEY,
            carrinhoJson);

        // Se estiver logado, também salva no banco.
        if (User?.Identity?.IsAuthenticated == true)
        {
            var userId =
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                await _cartRepository
                    .SaveCartJsonByUserIdAsync(
                        userId,
                        carrinhoJson);
            }
        }
    }
}

// =============================================================
// MODELOS DO CARRINHO
// =============================================================

public class CarrinhoSessao
{
    public List<ItemCarrinho> Itens { get; set; } = new();

    public decimal Total =>
        Itens.Sum(
            i => i.Preco * i.Quantidade);

    public int QuantidadeTotal =>
        Itens.Sum(
            i => i.Quantidade);
}

public class ItemCarrinho
{
    public int DoceId { get; set; }

    public string Nome { get; set; } =
        string.Empty;

    public decimal Preco { get; set; }

    public int Quantidade { get; set; }

    public string? CoverImageUrl { get; set; }
}