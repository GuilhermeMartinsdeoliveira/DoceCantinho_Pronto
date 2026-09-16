using DoceCantinho.Domain.Entities;
using DoceCantinho.Infrastructure.Context;
using DoceCantinho.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DoceCantinho.UI.Controllers
{
    [Authorize]
    public class CartoesController : Controller
    {
        private readonly DoceCantinhoDbContext _db;
        public CartoesController(DoceCantinhoDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
                return RedirectToAction("Login", "Account");

            var cartoes = await _db.Cartoes
                .AsNoTracking()
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CartaoResumoViewModel
                {
                    Id = c.Id,
                    NomeTitular = c.NomeTitular,
                    Ultimos4 = c.Ultimos4,
                    Bandeira = c.Bandeira,
                    Tipo = c.Tipo,
                    MesValidade = c.MesValidade,
                    AnoValidade = c.AnoValidade
                })
                .ToListAsync();

            ViewBag.Cartoes = cartoes;
            return View(new CartaoCadastroViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CartaoCadastroViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
                return RedirectToAction("Login", "Account");

            var numero = SomenteNumeros(model.Numero);

            if (numero.Length < 13 || numero.Length > 19)
                ModelState.AddModelError(nameof(model.Numero), "Informe um número de cartão válido.");

            if (!NumeroValidoLuhn(numero))
                ModelState.AddModelError(nameof(model.Numero), "O número do cartão informado não é válido.");

            if (model.MesValidade < 1 || model.MesValidade > 12)
                ModelState.AddModelError(nameof(model.MesValidade), "Informe um mês entre 01 e 12.");

            if (model.AnoValidade >= 1 && model.AnoValidade <= 9999 &&
                model.MesValidade >= 1 && model.MesValidade <= 12)
            {
                var primeiroDiaValidade = new DateTime(model.AnoValidade, model.MesValidade, 1);
                if (primeiroDiaValidade < new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1))
                    ModelState.AddModelError(nameof(model.AnoValidade), "O cartão precisa estar dentro da validade.");
            }

            if (model.Tipo is not ("Credito" or "Debito"))
                ModelState.AddModelError(nameof(model.Tipo), "Tipo de cartão inválido.");

            if (!ModelState.IsValid)
            {
                ViewBag.Cartoes = await ObterCartoesAsync(userId);
                return View(model);
            }

            var cartao = new Cartao
            {
                UserId = userId,
                NomeTitular = model.NomeTitular.Trim().ToUpperInvariant(),
                Ultimos4 = numero[^4..],
                Bandeira = model.Bandeira.Trim(),
                Tipo = model.Tipo,
                MesValidade = model.MesValidade,
                AnoValidade = model.AnoValidade,
                CreatedAt = DateTime.UtcNow
            };

            _db.Cartoes.Add(cartao);
            await _db.SaveChangesAsync();

            TempData["CartaoSucesso"] = $"Cartão •••• {cartao.Ultimos4} cadastrado com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
                return RedirectToAction("Login", "Account");

            var cartao = await _db.Cartoes
                .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

            if (cartao == null)
            {
                TempData["CartaoErro"] = "Cartão não encontrado.";
                return RedirectToAction(nameof(Index));
            }

            _db.Cartoes.Remove(cartao);
            await _db.SaveChangesAsync();

            TempData["CartaoSucesso"] = $"Cartão •••• {cartao.Ultimos4} removido.";
            return RedirectToAction(nameof(Index));
        }

        private async Task<List<CartaoResumoViewModel>> ObterCartoesAsync(string userId)
        {
            return await _db.Cartoes
                .AsNoTracking()
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CartaoResumoViewModel
                {
                    Id = c.Id,
                    NomeTitular = c.NomeTitular,
                    Ultimos4 = c.Ultimos4,
                    Bandeira = c.Bandeira,
                    Tipo = c.Tipo,
                    MesValidade = c.MesValidade,
                    AnoValidade = c.AnoValidade
                })
                .ToListAsync();
        }

        private static string SomenteNumeros(string? valor) =>
            new string((valor ?? string.Empty).Where(char.IsDigit).ToArray());

        private static bool NumeroValidoLuhn(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                return false;

            var soma = 0;
            var dobrar = false;

            for (var i = numero.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(numero[i]))
                    return false;

                var digito = numero[i] - '0';

                if (dobrar)
                {
                    digito *= 2;
                    if (digito > 9)
                        digito -= 9;
                }

                soma += digito;
                dobrar = !dobrar;
            }

            return soma % 10 == 0;
        }
    }
}
