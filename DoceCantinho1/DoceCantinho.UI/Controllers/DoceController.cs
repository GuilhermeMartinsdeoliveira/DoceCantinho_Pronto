// =============================================================================
// SenacGames.UI - GamesController (Área Pública)
// =============================================================================
// Controller para as páginas públicas de games.
// Permite visualizar o catálogo e detalhes dos games SEM autenticação.
// =============================================================================

using DoceCantinho.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DoceCantinho.Application.ViewModels;

namespace DoceCantinho.UI.Controllers
{
    /// <summary>
    /// Controller público de Games — catálogo e detalhes.
    /// NÃO requer autenticação.
    /// </summary>
    public class DocesController : Controller
    {
        private readonly IDoceService _doceService;
        private readonly ICategoryService _categoryService;

        public DocesController(IDoceService doceService, ICategoryService categoryService)
        {
            _doceService = doceService;
            _categoryService = categoryService;
        }

        /// <summary>
        /// Catálogo de games com filtro por categoria.
        /// URL: /Games ou /Games/Index
        /// </summary>
        public async Task<IActionResult> Index(int? categoryId)
        {
            var viewModel = new DoceListViewModel
            {
                Categories = await _categoryService.GetAllAsync(),
                SelectedCategoryId = categoryId
            };

            // Se uma categoria foi selecionada, filtra os games
            if (categoryId.HasValue)
            {
                viewModel.Doces = await _doceService.GetByCategoryAsync(categoryId.Value);
            }
            else
            {
                viewModel.Doces = await _doceService.GetAllAsync();
            }

            return View("~/Views/Doces/Index.cshtml", viewModel);
        }

        /// <summary>
        /// Detalhes de um game específico.
        /// URL: /Games/Details/5
        /// </summary>
        public async Task<IActionResult> Details(int id)
        {
            var doce = await _doceService.GetByIdAsync(id);

            if (doce == null)
                return NotFound();

            // Busca games relacionados (mesma categoria)
            var relatedDoces = await _doceService.GetByCategoryAsync(doce.CategoryId);

            var viewModel = new DoceDetailsViewModel
            {
                Doce = doce,
                RelatedDoce= relatedDoces.Where(g => g.Id != doce.Id).Take(4)
            };

            return View(viewModel);
        }
    }
}