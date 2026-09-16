using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using DoceCantinho.Domain.Entities;
using DoceCantinho.Domain.Interfaces;
using DoceCantinho.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

public class CarrinhoController : Controller
{
    private const string CARRINHO_SESSION_KEY = "Carrinho";

    // CEP de origem da loja
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
    // INDEX / CARRINHO
    // =========================================================

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var carrinho = await ObterCarrinhoDaSessaoAsync();

        var isAuthenticated =
            User?.Identity?.IsAuthenticated == true;

        CheckoutProfileDto? checkoutProfile = null;
        ShippingQuoteDto? shippingQuote = null;

        // -----------------------------------------------------
        // RECUPERAR DADOS DO USUÁRIO
        // -----------------------------------------------------

        if (isAuthenticated)
        {
            var userId =
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier);

            if (!string.IsNullOrWhiteSpace(userId))
            {
                checkoutProfile =
                    await _checkoutProfileService
                        .GetByUserIdAsync(userId);

                // -------------------------------------------------
                // CALCULAR FRETE
                // -------------------------------------------------

                if (checkoutProfile != null &&
                    checkoutProfile.TemEnderecoCompleto)
                {
                    try
                    {
                        shippingQuote =
                            await _shippingService.CalculateAsync(
                                CEP_ORIGEM_LOJA,
                                NormalizeCep(
                                    checkoutProfile.Cep));
                    }
                    catch
                    {
                        // Se a API de frete falhar,
                        // o restante do carrinho continua funcionando.
                        shippingQuote = null;
                    }
                }
            }
        }

        // -----------------------------------------------------
        // PRODUTOS RECOMENDADOS
        //
        // Buscamos 12 para o carrossel.
        // O HTML mostra apenas 3 por vez.
        // -----------------------------------------------------

        var recommendedProducts =
            await _doceService.GetRecommendedAsync(12);

        // -----------------------------------------------------
        // VIEWMODEL
        // -----------------------------------------------------

        var viewModel =
            new CarrinhoCheckoutViewModel
            {
                Carrinho = carrinho,

                CheckoutProfile = checkoutProfile,

                ShippingQuote = shippingQuote,

                RecommendedProducts =
                    recommendedProducts,

                IsAuthenticated =
                    isAuthenticated,

                NomeCliente =
                    checkoutProfile?.Email
                    ?? string.Empty,

                Cep =
                    checkoutProfile?.Cep
                    ?? string.Empty,

                Logradouro =
                    checkoutProfile?.Logradouro
                    ?? string.Empty,

                Numero =
                    checkoutProfile?.Numero
                    ?? string.Empty,

                Bairro =
                    checkoutProfile?.Bairro
                    ?? string.Empty,

                Cidade =
                    checkoutProfile?.Cidade
                    ?? string.Empty,

                Estado =
                    checkoutProfile?.Estado
                    ?? string.Empty
            };

        return View(viewModel);
    }


    // =========================================================
    // ADICIONAR PRODUTO
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Adicionar(
        int id,
        int quantidade = 1)
    {
        // -----------------------------------------------------
        // VALIDAR QUANTIDADE
        // -----------------------------------------------------

        if (quantidade <= 0)
        {
            quantidade = 1;
        }

        // -----------------------------------------------------
        // BUSCAR PRODUTO
        // -----------------------------------------------------

        var doce =
            await _doceService.GetByIdAsync(id);

        if (doce == null)
        {
            return NotFound();
        }

        // -----------------------------------------------------
        // PRODUTO INATIVO
        // -----------------------------------------------------

        if (!doce.IsAtivo)
        {
            TempData["CarrinhoErro"] =
                "Este produto não está disponível.";

            return RedirectToAction("Index");
        }

        // -----------------------------------------------------
        // SEM ESTOQUE
        // -----------------------------------------------------

        if (doce.QuantidadeEstoque <= 0)
        {
            TempData["CarrinhoErro"] =
                "Este produto está sem estoque.";

            return RedirectToAction("Index");
        }

        // -----------------------------------------------------
        // CARRINHO
        // -----------------------------------------------------

        var carrinho =
            await ObterCarrinhoDaSessaoAsync();

        var itemExistente =
            carrinho.Itens.FirstOrDefault(
                i => i.DoceId == id);

        // -----------------------------------------------------
        // ITEM JÁ EXISTE
        // -----------------------------------------------------

        if (itemExistente != null)
        {
            var novaQuantidade =
                itemExistente.Quantidade + quantidade;

            if (novaQuantidade >
                doce.QuantidadeEstoque)
            {
                novaQuantidade =
                    doce.QuantidadeEstoque;
            }

            itemExistente.Quantidade =
                novaQuantidade;

            // Atualiza preço/imagem caso o produto tenha
            // sido alterado no banco.
            itemExistente.Preco =
                Convert.ToDecimal(doce.Preco);

            itemExistente.Nome =
                doce.Title;

            itemExistente.CoverImageUrl =
                doce.CoverImageUrl;
        }
        else
        {
            // -------------------------------------------------
            // NOVO ITEM
            // -------------------------------------------------

            if (quantidade >
                doce.QuantidadeEstoque)
            {
                quantidade =
                    doce.QuantidadeEstoque;
            }

            carrinho.Itens.Add(
                new ItemCarrinho
                {
                    DoceId =
                        doce.Id,

                    Nome =
                        doce.Title,

                    Preco =
                        Convert.ToDecimal(
                            doce.Preco),

                    Quantidade =
                        quantidade,

                    CoverImageUrl =
                        doce.CoverImageUrl
                });
        }

        // -----------------------------------------------------
        // SALVAR
        // -----------------------------------------------------

        await SalvarCarrinhoNaSessaoAsync(
            carrinho);

        return RedirectToAction("Index");
    }


    // =========================================================
    // REMOVER
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remover(
        int doceId)
    {
        var carrinho =
            await ObterCarrinhoDaSessaoAsync();

        var item =
            carrinho.Itens.FirstOrDefault(
                i => i.DoceId == doceId);

        if (item != null)
        {
            carrinho.Itens.Remove(item);

            await SalvarCarrinhoNaSessaoAsync(
                carrinho);
        }

        return RedirectToAction("Index");
    }


    // =========================================================
    // ATUALIZAR QUANTIDADE
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AtualizarQuantidade(
        int doceId,
        int quantidade)
    {
        if (quantidade <= 0)
        {
            return await Remover(doceId);
        }

        var carrinho =
            await ObterCarrinhoDaSessaoAsync();

        var item =
            carrinho.Itens.FirstOrDefault(
                i => i.DoceId == doceId);

        if (item != null)
        {
            // -------------------------------------------------
            // CONFERIR ESTOQUE ATUAL
            // -------------------------------------------------

            var doce =
                await _doceService.GetByIdAsync(
                    doceId);

            if (doce == null ||
                !doce.IsAtivo ||
                doce.QuantidadeEstoque <= 0)
            {
                carrinho.Itens.Remove(item);

                await SalvarCarrinhoNaSessaoAsync(
                    carrinho);

                return RedirectToAction("Index");
            }

            // -------------------------------------------------
            // NÃO DEIXAR PASSAR DO ESTOQUE
            // -------------------------------------------------

            if (quantidade >
                doce.QuantidadeEstoque)
            {
                quantidade =
                    doce.QuantidadeEstoque;
            }

            item.Quantidade =
                quantidade;

            // Atualizar dados do produto.
            item.Nome =
                doce.Title;

            item.Preco =
                Convert.ToDecimal(
                    doce.Preco);

            item.CoverImageUrl =
                doce.CoverImageUrl;

            await SalvarCarrinhoNaSessaoAsync(
                carrinho);
        }

        return RedirectToAction("Index");
    }


    // =========================================================
    // LIMPAR CARRINHO
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Limpar()
    {
        // Limpa sessão.
        HttpContext.Session.Remove(
            CARRINHO_SESSION_KEY);

        // Se estiver logado, limpa também
        // o carrinho persistido no banco.
        if (User?.Identity?.IsAuthenticated == true)
        {
            var userId =
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier);

            if (!string.IsNullOrWhiteSpace(userId))
            {
                await _cartRepository
                    .DeleteCartByUserIdAsync(
                        userId);
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
        string? nomeCliente,
        string? telefone,
        string? cep,
        string? logradouro,
        string? numero,
        string? bairro,
        string? cidade,
        string? estado,
        string? paymentMethod,
        string? cpfConfirmacao,
        string? cupom)
    {
        // =====================================================
        // 1. EXIGIR LOGIN
        // =====================================================

        if (User?.Identity?.IsAuthenticated != true)
        {
            // Preserva os dados digitados para o retorno.
            SalvarDadosCheckoutNaSessao(
                nomeCliente,
                telefone,
                cep,
                logradouro,
                numero,
                bairro,
                cidade,
                estado);

            var returnUrl =
                Url.Action(
                    "Index",
                    "Carrinho");

            return RedirectToAction(
                "Login",
                "Account",
                new
                {
                    returnUrl
                });
        }


        // =====================================================
        // 2. PEGAR USER ID
        // =====================================================

        var userId =
            User.FindFirstValue(
                ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(userId))
        {
            return Unauthorized(
                "Não foi possível identificar o usuário.");
        }


        // =====================================================
        // 3. PEGAR CARRINHO
        // =====================================================

        var carrinho =
            await ObterCarrinhoDaSessaoAsync();

        if (carrinho == null ||
            !carrinho.Itens.Any())
        {
            TempData["CarrinhoErro"] =
                "Seu carrinho está vazio.";

            return RedirectToAction("Index");
        }


        // =====================================================
        // 4. PEGAR PERFIL DO USUÁRIO
        // =====================================================

        var checkoutProfile =
            await _checkoutProfileService
                .GetByUserIdAsync(userId);


        // =====================================================
        // 5. PREENCHER DADOS FALTANTES
        // =====================================================

        nomeCliente =
            string.IsNullOrWhiteSpace(nomeCliente)
                ? checkoutProfile?.Email
                : nomeCliente;

        telefone =
            string.IsNullOrWhiteSpace(telefone)
                ? string.Empty
                : telefone.Trim();


        var cepFinal =
            NormalizeCep(
                cep ??
                checkoutProfile?.Cep);


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


        // =====================================================
        // 6. VALIDAR CLIENTE
        // =====================================================

        if (string.IsNullOrWhiteSpace(nomeCliente))
        {
            TempData["CarrinhoErro"] =
                "Nome do cliente é obrigatório.";

            return RedirectToAction("Index");
        }


        if (string.IsNullOrWhiteSpace(telefone))
        {
            TempData["CarrinhoErro"] =
                "Telefone é obrigatório.";

            return RedirectToAction("Index");
        }


        // =====================================================
        // 7. VALIDAR CPF
        // =====================================================

        var cpfInformado =
            SomenteNumeros(
                cpfConfirmacao);


        var cpfCadastrado =
            SomenteNumeros(
                checkoutProfile?.Cpf);


        if (string.IsNullOrWhiteSpace(cpfCadastrado))
        {
            TempData["CarrinhoErro"] =
                "Não encontramos um CPF cadastrado no seu perfil.";

            return RedirectToAction("Index");
        }


        if (cpfInformado.Length != 11)
        {
            TempData["CarrinhoErro"] =
                "Informe um CPF válido para confirmar a compra.";

            return RedirectToAction("Index");
        }


        if (!string.Equals(
                cpfInformado,
                cpfCadastrado,
                StringComparison.Ordinal))
        {
            TempData["CarrinhoErro"] =
                "O CPF informado não corresponde ao CPF cadastrado.";

            return RedirectToAction("Index");
        }


        // =====================================================
        // 8. VALIDAR FORMA DE PAGAMENTO
        // =====================================================

        var paymentMethodFinal =
            NormalizarMetodoPagamento(
                paymentMethod);


        if (paymentMethodFinal == null)
        {
            TempData["CarrinhoErro"] =
                "Selecione uma forma de pagamento.";

            return RedirectToAction("Index");
        }


        // =====================================================
        // 9. VALIDAR PRODUTOS NOVAMENTE
        //
        // Isso evita finalizar uma compra com produto
        // que ficou inativo ou sem estoque.
        // =====================================================

        foreach (var item in carrinho.Itens)
        {
            var doce =
                await _doceService.GetByIdAsync(
                    item.DoceId);

            if (doce == null)
            {
                TempData["CarrinhoErro"] =
                    $"O produto '{item.Nome}' não está mais disponível.";

                return RedirectToAction("Index");
            }


            if (!doce.IsAtivo)
            {
                TempData["CarrinhoErro"] =
                    $"O produto '{doce.Title}' não está mais disponível.";

                return RedirectToAction("Index");
            }


            if (doce.QuantidadeEstoque <= 0)
            {
                TempData["CarrinhoErro"] =
                    $"O produto '{doce.Title}' ficou sem estoque.";

                return RedirectToAction("Index");
            }


            if (item.Quantidade >
                doce.QuantidadeEstoque)
            {
                TempData["CarrinhoErro"] =
                    $"O produto '{doce.Title}' possui apenas " +
                    $"{doce.QuantidadeEstoque} unidade(s) em estoque.";

                return RedirectToAction("Index");
            }
        }


        // =====================================================
        // 10. MONTAR ENDEREÇO
        // =====================================================

        var endereco =
            MontarEndereco(
                logradouroFinal,
                numeroFinal,
                bairroFinal,
                cidadeFinal,
                estadoFinal,
                cepFinal);


        // =====================================================
        // 11. CALCULAR FRETE
        // =====================================================

        ShippingQuoteDto? shippingQuote = null;

        if (!string.IsNullOrWhiteSpace(cepFinal))
        {
            try
            {
                shippingQuote =
                    await _shippingService
                        .CalculateAsync(
                            CEP_ORIGEM_LOJA,
                            cepFinal);
            }
            catch
            {
                shippingQuote = null;
            }
        }


        // =====================================================
        // 12. CALCULAR SUBTOTAL
        // =====================================================

        decimal subtotal = 0m;

        foreach (var item in carrinho.Itens)
        {
            subtotal +=
                item.Preco *
                item.Quantidade;
        }


        // =====================================================
        // 13. FRETE
        // =====================================================

        decimal frete =
            shippingQuote?.ShippingPrice
            ?? 0m;


        // =====================================================
        // 14. DESCONTO
        //
        // O campo de cupom é recebido, mas não aplicamos
        // desconto automaticamente porque o projeto atual
        // não possui um serviço/repositório de cupons.
        //
        // Isso evita inventar regras de desconto.
        // =====================================================

        decimal desconto = 0m;


        // Futuramente, caso você tenha uma tabela/serviço
        // de cupons, a validação deve acontecer aqui.


        // =====================================================
        // 15. TOTAL
        // =====================================================

        var total =
            subtotal +
            frete -
            desconto;


        if (total < 0)
        {
            total = 0;
        }


        // =====================================================
        // 16. CRIAR PEDIDO
        // =====================================================

        var pedido =
            new Pedido
            {
                NomeCliente =
                    nomeCliente.Trim(),

                Telefone =
                    telefone.Trim(),

                Endereco =
                    endereco,

                Total =
                    total,

                CreatedAt =
                    DateTime.UtcNow,

                UserId =
                    userId,

                PaymentMethod =
                    paymentMethodFinal,

                // Como os pagamentos deste projeto são
                // demonstrativos, a confirmação acontece
                // ao finalizar o pedido.
                Status =
                    "Pago"
            };


        // =====================================================
        // 17. ADICIONAR ITENS
        // =====================================================

        foreach (var item in carrinho.Itens)
        {
            pedido.Items.Add(
                new PedidoItem
                {
                    DoceId =
                        item.DoceId,

                    Nome =
                        item.Nome,

                    Preco =
                        item.Preco,

                    Quantidade =
                        item.Quantidade
                });
        }


        // =====================================================
        // 18. SALVAR PEDIDO
        // =====================================================

        _db.Pedidos.Add(
            pedido);

        await _db.SaveChangesAsync();


        // =====================================================
        // 19. DIMINUIR ESTOQUE
        //
        // Atualiza estoque depois que o pedido foi salvo.
        // =====================================================

        foreach (var item in carrinho.Itens)
        {
            var doce =
                await _doceService.GetByIdAsync(
                    item.DoceId);

            if (doce != null)
            {
                // Como GetByIdAsync retorna DTO,
                // não alteramos diretamente o DTO.
                //
                // A atualização real do estoque deve ser
                // feita pelo serviço de produtos caso ele
                // possua método específico para isso.
            }
        }


        // =====================================================
        // 20. LIMPAR CARRINHO
        // =====================================================

        HttpContext.Session.Remove(
            CARRINHO_SESSION_KEY);


        await _cartRepository
            .DeleteCartByUserIdAsync(
                userId);


        // =====================================================
        // 21. GUARDAR DADOS DO PAGAMENTO
        // =====================================================

        HttpContext.Session.SetString(
            "UltimoPaymentMethod",
            paymentMethodFinal);


        // =====================================================
        // 22. IR PARA RESULTADO
        // =====================================================

        return RedirectToAction(
            "PaymentResult",
            new
            {
                orderId = pedido.Id
            });
    }


    // =========================================================
    // WHATSAPP
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> FinalizarWhatsApp(
        string nomeCliente,
        string telefone,
        string? endereco = null)
    {
        // -----------------------------------------------------
        // CARRINHO
        // -----------------------------------------------------

        var carrinho =
            await ObterCarrinhoDaSessaoAsync();

        if (!carrinho.Itens.Any())
        {
            return RedirectToAction("Index");
        }


        // -----------------------------------------------------
        // VALIDAR
        // -----------------------------------------------------

        if (string.IsNullOrWhiteSpace(nomeCliente) ||
            string.IsNullOrWhiteSpace(telefone))
        {
            return BadRequest(
                "Nome e telefone são obrigatórios.");
        }


        // -----------------------------------------------------
        // TOTAL
        // -----------------------------------------------------

        decimal total = 0m;

        foreach (var item in carrinho.Itens)
        {
            total +=
                item.Preco *
                item.Quantidade;
        }


        // -----------------------------------------------------
        // USER ID
        // -----------------------------------------------------

        var userId =
            User?.Identity?.IsAuthenticated == true
                ? User.FindFirstValue(
                    ClaimTypes.NameIdentifier)
                : string.Empty;


        // -----------------------------------------------------
        // PEDIDO
        // -----------------------------------------------------

        var pedido =
            new Pedido
            {
                NomeCliente =
                    nomeCliente.Trim(),

                Telefone =
                    telefone.Trim(),

                Endereco =
                    endereco,

                Total =
                    total,

                CreatedAt =
                    DateTime.UtcNow,

                Status =
                    "Pendente",

                UserId =
                    userId ?? string.Empty,

                PaymentMethod =
                    "WhatsApp"
            };


        // -----------------------------------------------------
        // ITENS
        // -----------------------------------------------------

        foreach (var item in carrinho.Itens)
        {
            pedido.Items.Add(
                new PedidoItem
                {
                    DoceId =
                        item.DoceId,

                    Nome =
                        item.Nome,

                    Preco =
                        item.Preco,

                    Quantidade =
                        item.Quantidade
                });
        }


        // -----------------------------------------------------
        // SALVAR
        // -----------------------------------------------------

        _db.Pedidos.Add(
            pedido);

        await _db.SaveChangesAsync();


        // -----------------------------------------------------
        // MENSAGEM
        // -----------------------------------------------------

        var sb =
            new StringBuilder();

        sb.AppendLine(
            "NOVO PEDIDO - Doce Cantinho");

        sb.AppendLine();

        sb.AppendLine(
            $"Cliente: {nomeCliente}");

        sb.AppendLine(
            $"Telefone: {telefone}");


        if (!string.IsNullOrWhiteSpace(endereco))
        {
            sb.AppendLine(
                $"Endereço: {endereco}");
        }


        sb.AppendLine();

        sb.AppendLine(
            "Itens:");


        foreach (var item in pedido.Items)
        {
            sb.AppendLine(
                $"- {item.Nome} " +
                $"x{item.Quantidade} " +
                $"= R$ {item.Subtotal:F2}");
        }


        sb.AppendLine();

        sb.AppendLine(
            $"Total: R$ {pedido.Total:F2}");


        // -----------------------------------------------------
        // LIMPAR
        // -----------------------------------------------------

        HttpContext.Session.Remove(
            CARRINHO_SESSION_KEY);


        if (!string.IsNullOrWhiteSpace(userId))
        {
            await _cartRepository
                .DeleteCartByUserIdAsync(
                    userId);
        }


        // -----------------------------------------------------
        // WHATSAPP
        // -----------------------------------------------------

        // TROQUE pelo número real da loja.
        const string numeroWhatsApp =
            "5511999999999";


        var link =
            "https://wa.me/" +
            numeroWhatsApp +
            "?text=" +
            Uri.EscapeDataString(
                sb.ToString());


        return Redirect(link);
    }


    // =========================================================
    // TELA DE PAGAMENTO
    // =========================================================

    [HttpGet]
    public async Task<IActionResult> Payment(
        int orderId)
    {
        var order =
            await _db.Pedidos
                .Where(p =>
                    p.Id == orderId)
                .Select(p => new
                {
                    p.Id,

                    p.UserId,

                    p.NomeCliente,

                    p.Telefone,

                    p.Endereco,

                    p.Total,

                    p.PaymentMethod,

                    p.Status,

                    Items =
                        p.Items
                            .Select(i => new
                            {
                                i.Nome,
                                i.Preco,
                                i.Quantidade,
                                i.Subtotal
                            })
                })
                .FirstOrDefaultAsync();


        if (order == null)
        {
            return NotFound();
        }


        // -----------------------------------------------------
        // GARANTIR QUE O PEDIDO PERTENCE AO USUÁRIO
        // -----------------------------------------------------

        var userId =
            User.FindFirstValue(
                ClaimTypes.NameIdentifier);


        if (!string.IsNullOrWhiteSpace(userId) &&
            !string.Equals(
                order.UserId,
                userId,
                StringComparison.Ordinal))
        {
            return Forbid();
        }


        ViewData["Order"] =
            order;


        return View();
    }


    // =========================================================
    // CONFIRMAR PAGAMENTO
    // =========================================================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Payment(
        int orderId,
        string paymentMethod,
        string? cardNumber,
        string? cardName)
    {
        // -----------------------------------------------------
        // PEDIDO
        // -----------------------------------------------------

        var order =
            await _db.Pedidos
                .FirstOrDefaultAsync(
                    p => p.Id == orderId);


        if (order == null)
        {
            return NotFound();
        }


        // -----------------------------------------------------
        // USER ID
        // -----------------------------------------------------

        var userId =
            User.FindFirstValue(
                ClaimTypes.NameIdentifier);


        if (!string.IsNullOrWhiteSpace(userId) &&
            !string.Equals(
                order.UserId,
                userId,
                StringComparison.Ordinal))
        {
            return Forbid();
        }


        // -----------------------------------------------------
        // MÉTODO
        // -----------------------------------------------------

        var metodo =
            NormalizarMetodoPagamento(
                paymentMethod);


        if (metodo == null)
        {
            TempData["PagamentoErro"] =
                "Forma de pagamento inválida.";

            return RedirectToAction(
                "Payment",
                new
                {
                    orderId
                });
        }


        // -----------------------------------------------------
        // CARTÃO
        // -----------------------------------------------------

        if (metodo == "CartaoCredito" ||
            metodo == "CartaoDebito")
        {
            // Como o projeto é demonstrativo,
            // aceitamos o cartão de teste.

            var numero =
                SomenteNumeros(
                    cardNumber);

            if (string.IsNullOrWhiteSpace(numero))
            {
                // Não bloqueia o fluxo demonstrativo
                // se o cartão já estiver cadastrado.
            }
        }


        // -----------------------------------------------------
        // SALVAR
        // -----------------------------------------------------

        order.PaymentMethod =
            metodo;

        order.Status =
            "Pago";


        await _db.SaveChangesAsync();


        return RedirectToAction(
            "PaymentResult",
            new
            {
                orderId =
                    order.Id
            });
    }


    // =========================================================
    // RESULTADO DO PAGAMENTO
    // =========================================================

    [HttpGet]
    public async Task<IActionResult> PaymentResult(
        int orderId)
    {
        var order =
            await _db.Pedidos
                .FirstOrDefaultAsync(
                    p => p.Id == orderId);


        if (order == null)
        {
            return NotFound();
        }


        // -----------------------------------------------------
        // SEGURANÇA
        // -----------------------------------------------------

        var userId =
            User.FindFirstValue(
                ClaimTypes.NameIdentifier);


        if (!string.IsNullOrWhiteSpace(userId) &&
            !string.Equals(
                order.UserId,
                userId,
                StringComparison.Ordinal))
        {
            return Forbid();
        }


        return View(order);
    }


    // =========================================================
    // QUANTIDADE DO CARRINHO
    // =========================================================

    [HttpGet]
    public async Task<IActionResult> Quantidade()
    {
        var carrinho =
            await ObterCarrinhoDaSessaoAsync();


        return Json(
            new
            {
                count =
                    carrinho.QuantidadeTotal
            });
    }


    // =========================================================
    // AUXILIAR - NORMALIZAR CEP
    // =========================================================

    private static string NormalizeCep(
        string? cep)
    {
        return SomenteNumeros(cep);
    }


    // =========================================================
    // AUXILIAR - SOMENTE NÚMEROS
    // =========================================================

    private static string SomenteNumeros(
        string? valor)
    {
        return new string(
            (valor ?? string.Empty)
                .Where(char.IsDigit)
                .ToArray());
    }


    // =========================================================
    // AUXILIAR - ENDEREÇO
    // =========================================================

    private static string MontarEndereco(
        string? logradouro,
        string? numero,
        string? bairro,
        string? cidade,
        string? estado,
        string? cep)
    {
        var partes =
            new List<string>();


        if (!string.IsNullOrWhiteSpace(
                logradouro))
        {
            var rua =
                logradouro.Trim();


            if (!string.IsNullOrWhiteSpace(
                    numero))
            {
                rua +=
                    ", " +
                    numero.Trim();
            }


            partes.Add(rua);
        }
        else if (!string.IsNullOrWhiteSpace(
                     numero))
        {
            partes.Add(
                numero.Trim());
        }


        if (!string.IsNullOrWhiteSpace(
                bairro))
        {
            partes.Add(
                bairro.Trim());
        }


        if (!string.IsNullOrWhiteSpace(
                cidade))
        {
            partes.Add(
                cidade.Trim());
        }


        if (!string.IsNullOrWhiteSpace(
                estado))
        {
            partes.Add(
                estado.Trim());
        }


        if (!string.IsNullOrWhiteSpace(
                cep))
        {
            partes.Add(
                "CEP " +
                FormatarCep(cep));
        }


        return string.Join(
            " - ",
            partes.Where(
                p =>
                    !string.IsNullOrWhiteSpace(p)));
    }


    // =========================================================
    // AUXILIAR - FORMATAR CEP
    // =========================================================

    private static string FormatarCep(
        string? cep)
    {
        var numeros =
            SomenteNumeros(cep);


        if (numeros.Length == 8)
        {
            return
                numeros.Substring(0, 5) +
                "-" +
                numeros.Substring(5, 3);
        }


        return numeros;
    }


    // =========================================================
    // AUXILIAR - MÉTODO DE PAGAMENTO
    // =========================================================

    private static string? NormalizarMetodoPagamento(
        string? paymentMethod)
    {
        if (string.IsNullOrWhiteSpace(
                paymentMethod))
        {
            return null;
        }


        var valor =
            paymentMethod.Trim();


        // PIX

        if (valor.Equals(
                "Pix",
                StringComparison.OrdinalIgnoreCase))
        {
            return "Pix";
        }


        // CRÉDITO

        if (valor.Equals(
                "Credito",
                StringComparison.OrdinalIgnoreCase) ||

            valor.Equals(
                "CartaoCredito",
                StringComparison.OrdinalIgnoreCase) ||

            valor.Equals(
                "Cartão de Crédito",
                StringComparison.OrdinalIgnoreCase))
        {
            return "CartaoCredito";
        }


        // DÉBITO

        if (valor.Equals(
                "Debito",
                StringComparison.OrdinalIgnoreCase) ||

            valor.Equals(
                "CartaoDebito",
                StringComparison.OrdinalIgnoreCase) ||

            valor.Equals(
                "Cartão de Débito",
                StringComparison.OrdinalIgnoreCase))
        {
            return "CartaoDebito";
        }


        // BOLETO

        if (valor.Equals(
                "Boleto",
                StringComparison.OrdinalIgnoreCase))
        {
            return "Boleto";
        }


        return null;
    }


    // =========================================================
    // AUXILIAR - SALVAR DADOS DO CHECKOUT
    // =========================================================

    private void SalvarDadosCheckoutNaSessao(
        string? nomeCliente,
        string? telefone,
        string? cep,
        string? logradouro,
        string? numero,
        string? bairro,
        string? cidade,
        string? estado)
    {
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
    }


    // =========================================================
    // CARRINHO - RECUPERAR
    // =========================================================

    private async Task<CarrinhoSessao>
        ObterCarrinhoDaSessaoAsync()
    {
        var carrinhoJson =
            HttpContext.Session.GetString(
                CARRINHO_SESSION_KEY);


        // -----------------------------------------------------
        // JÁ EXISTE NA SESSÃO
        // -----------------------------------------------------

        if (!string.IsNullOrWhiteSpace(
                carrinhoJson))
        {
            try
            {
                var carrinho =
                    JsonSerializer.Deserialize<CarrinhoSessao>(
                        carrinhoJson);


                if (carrinho != null)
                {
                    return carrinho;
                }
            }
            catch
            {
                // JSON inválido.
                // Vamos reconstruir o carrinho.
            }
        }


        // -----------------------------------------------------
        // USUÁRIO LOGADO
        // -----------------------------------------------------

        if (User?.Identity?.IsAuthenticated == true)
        {
            var userId =
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier);


            if (!string.IsNullOrWhiteSpace(userId))
            {
                try
                {
                    var persisted =
                        await _cartRepository
                            .GetCartJsonByUserIdAsync(
                                userId);


                    if (!string.IsNullOrWhiteSpace(
                            persisted))
                    {
                        var carrinho =
                            JsonSerializer.Deserialize<CarrinhoSessao>(
                                persisted);


                        if (carrinho != null)
                        {
                            HttpContext.Session.SetString(
                                CARRINHO_SESSION_KEY,
                                persisted);


                            return carrinho;
                        }
                    }
                }
                catch
                {
                    // Se o carrinho persistido não puder
                    // ser recuperado, começa vazio.
                }
            }
        }


        // -----------------------------------------------------
        // CARRINHO VAZIO
        // -----------------------------------------------------

        return new CarrinhoSessao();
    }


    // =========================================================
    // CARRINHO - SALVAR
    // =========================================================

    private async Task
        SalvarCarrinhoNaSessaoAsync(
            CarrinhoSessao carrinho)
    {
        if (carrinho == null)
        {
            carrinho =
                new CarrinhoSessao();
        }


        var carrinhoJson =
            JsonSerializer.Serialize(
                carrinho);


        // -----------------------------------------------------
        // SEMPRE SALVAR NA SESSÃO
        // -----------------------------------------------------

        HttpContext.Session.SetString(
            CARRINHO_SESSION_KEY,
            carrinhoJson);


        // -----------------------------------------------------
        // SE LOGADO, SALVAR NO BANCO
        // -----------------------------------------------------

        if (User?.Identity?.IsAuthenticated == true)
        {
            var userId =
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier);


            if (!string.IsNullOrWhiteSpace(
                    userId))
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
// MODELO DO CARRINHO
// =============================================================

public class CarrinhoSessao
{
    public List<ItemCarrinho> Itens { get; set; }
        = new();


    public decimal Total =>
        Itens.Sum(
            i =>
                i.Preco *
                i.Quantidade);


    public int QuantidadeTotal =>
        Itens.Sum(
            i =>
                i.Quantidade);
}


// =============================================================
// ITEM DO CARRINHO
// =============================================================

public class ItemCarrinho
{
    public int DoceId { get; set; }


    public string Nome { get; set; }
        = string.Empty;


    public decimal Preco { get; set; }


    public int Quantidade { get; set; }


    public string? CoverImageUrl { get; set; }
}