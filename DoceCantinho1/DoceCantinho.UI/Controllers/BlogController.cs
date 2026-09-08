using System.Linq;
using DoceCantinho.UI.Data;
using DoceCantinho.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoceCantinho.UI.Controllers
{
    public class BlogController : Controller
    {
        // Hoje os posts vêm de uma lista em memória (BlogSeedData).
        // Isso já entrega o Blog funcionando de ponta a ponta, sem precisar
        // criar tabela nova no banco. No futuro, basta trocar esta chamada
        // por um IBlogService injetado via DI, seguindo o mesmo padrão
        // usado em IDoceService / ICategoryService.
        public IActionResult Index(string? categoria)
        {
            var posts = BlogSeedData.GetPosts()
                .OrderByDescending(p => p.PublishedAt)
                .ToList();

            var categorias = posts.Select(p => p.Category).Distinct().OrderBy(c => c).ToList();

            var filtrados = string.IsNullOrWhiteSpace(categoria)
                ? posts
                : posts.Where(p => p.Category.Equals(categoria, System.StringComparison.OrdinalIgnoreCase)).ToList();

            var destaque = posts.FirstOrDefault(p => p.Featured) ?? posts.FirstOrDefault();

            var viewModel = new BlogIndexViewModel
            {
                Posts = filtrados.Where(p => destaque == null || p.Slug != destaque.Slug || !string.IsNullOrWhiteSpace(categoria)),
                FeaturedPost = string.IsNullOrWhiteSpace(categoria) ? destaque : null,
                Categories = categorias,
                SelectedCategory = categoria
            };

            return View(viewModel);
        }

        public IActionResult Details(string id)
        {
            var posts = BlogSeedData.GetPosts();
            var post = posts.FirstOrDefault(p => p.Slug == id);

            if (post == null)
            {
                return NotFound();
            }

            var relacionados = posts
                .Where(p => p.Slug != post.Slug && p.Category == post.Category)
                .Take(3)
                .ToList();

            if (relacionados.Count < 3)
            {
                relacionados.AddRange(
                    posts.Where(p => p.Slug != post.Slug && !relacionados.Contains(p))
                         .Take(3 - relacionados.Count));
            }

            var viewModel = new BlogDetailsViewModel
            {
                Post = post,
                RelatedPosts = relacionados
            };

            return View(viewModel);
        }
    }
}
