using DoceCantinho.Application.Interfaces;
using DoceCantinho.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoceCantinho.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDoceService _doceService;
        private readonly ICategoryService _categoryService;

        public HomeController(IDoceService doceService, ICategoryService categoryService)
        {
            _doceService = doceService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                FeaturedDoce = await _doceService.GetFeaturedAsync(),
                Categories   = await _categoryService.GetAllAsync(),
                RecentDoce   = (await _doceService.GetAllAsync()).Take(4)
            };

            return View(viewModel);
        }

        public IActionResult Sobre()    => View();
        public IActionResult Servicos() => View();
        public IActionResult Contato()  => View();
        public IActionResult Privacy()  => View();
    }
}
