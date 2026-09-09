using DoceCantinho.Domain.Entities;
using DoceCantinho.Infrastructure.Context;
using DoceCantinho.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoceCantinho.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly DoceCantinhoDbContext _db;

        public BlogController(DoceCantinhoDbContext db)
        {
            _db = db;
        }

        // ==========================================
        // LISTAGEM PÚBLICA DO BLOG
        // ==========================================
        public async Task<IActionResult> Index(string? categoria)
        {
            var query = _db.BlogPosts
                .AsNoTracking()
                .Where(p => p.IsPublished);

            if (!string.IsNullOrWhiteSpace(categoria))
            {
                query = query.Where(p => p.Category == categoria);
            }

            var postsBanco = await query
                .OrderByDescending(p => p.PublishedAt)
                .ToListAsync();

            var todosPublicados = await _db.BlogPosts
                .AsNoTracking()
                .Where(p => p.IsPublished)
                .OrderByDescending(p => p.PublishedAt)
                .ToListAsync();

            var posts = postsBanco
                .Select(MapearPost)
                .ToList();

            var todos = todosPublicados
                .Select(MapearPost)
                .ToList();

            var categorias = todos
                .Select(p => p.Category)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            BlogPostViewModel? destaque = null;

            if (string.IsNullOrWhiteSpace(categoria))
            {
                destaque = todos.FirstOrDefault(p => p.Featured)
                           ?? todos.FirstOrDefault();
            }

            var viewModel = new BlogIndexViewModel
            {
                FeaturedPost = destaque,

                Posts = posts.Where(p =>
                    destaque == null ||
                    p.Slug != destaque.Slug ||
                    !string.IsNullOrWhiteSpace(categoria)),

                Categories = categorias,

                SelectedCategory = categoria
            };

            return View(viewModel);
        }

        // ==========================================
        // DETALHES DO ARTIGO
        // ==========================================
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var postBanco = await _db.BlogPosts
                .AsNoTracking()
                .FirstOrDefaultAsync(p =>
                    p.Slug == id &&
                    p.IsPublished);

            if (postBanco == null)
                return NotFound();

            var post = MapearPost(postBanco);

            var relacionadosBanco = await _db.BlogPosts
                .AsNoTracking()
                .Where(p =>
                    p.Id != postBanco.Id &&
                    p.IsPublished)
                .OrderByDescending(p => p.Category == postBanco.Category)
                .ThenByDescending(p => p.PublishedAt)
                .Take(3)
                .ToListAsync();

            var viewModel = new BlogDetailsViewModel
            {
                Post = post,
                RelatedPosts = relacionadosBanco
                    .Select(MapearPost)
                    .ToList()
            };

            return View(viewModel);
        }

        // ==========================================
        // CONVERTE ENTIDADE DO BANCO PARA O MODEL
        // QUE SUAS VIEWS DO BLOG JÁ UTILIZAM
        // ==========================================
        private static BlogPostViewModel MapearPost(BlogPost post)
        {
            return new BlogPostViewModel
            {
                Slug = post.Slug,
                Title = post.Title,
                Excerpt = post.Excerpt,
                CoverImageUrl = post.CoverImageUrl,
                Category = post.Category,

                Tags = string.IsNullOrWhiteSpace(post.Tags)
                    ? new List<string>()
                    : post.Tags
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(t => t.Trim())
                        .Where(t => !string.IsNullOrWhiteSpace(t))
                        .ToList(),

                PublishedAt = post.PublishedAt,

                AuthorName = post.AuthorName,

                AuthorRole = post.AuthorRole ?? string.Empty,

                AuthorAvatar = string.IsNullOrWhiteSpace(post.AuthorAvatar)
                    ? "/imagens/autores/confeiteira.jpg"
                    : post.AuthorAvatar,

                AuthorBio = post.AuthorBio ?? string.Empty,

                Featured = post.Featured,

                Content = ConverterConteudo(post.Content)
            };
        }

        // ==========================================
        // CONVERTE O TEXTO DIGITADO PELO ADMIN
        // NOS BLOCOS QUE SUA VIEW Details JÁ USA
        // ==========================================
        private static List<BlogContentBlock> ConverterConteudo(string? conteudo)
        {
            var blocos = new List<BlogContentBlock>();

            if (string.IsNullOrWhiteSpace(conteudo))
                return blocos;

            var linhas = conteudo.Replace("\r\n", "\n").Split('\n');

            var itensLista = new List<string>();

            void AdicionarLista()
            {
                if (itensLista.Count > 0)
                {
                    blocos.Add(new BlogContentBlock
                    {
                        Type = BlogBlockType.List,
                        Items = new List<string>(itensLista)
                    });

                    itensLista.Clear();
                }
            }

            foreach (var linhaOriginal in linhas)
            {
                var linha = linhaOriginal.Trim();

                if (string.IsNullOrWhiteSpace(linha))
                {
                    AdicionarLista();
                    continue;
                }

                // Título principal da seção
                if (linha.StartsWith("## "))
                {
                    AdicionarLista();

                    blocos.Add(new BlogContentBlock
                    {
                        Type = BlogBlockType.Heading,
                        Text = linha.Substring(3).Trim()
                    });

                    continue;
                }

                // Subtítulo
                if (linha.StartsWith("### "))
                {
                    AdicionarLista();

                    blocos.Add(new BlogContentBlock
                    {
                        Type = BlogBlockType.SubHeading,
                        Text = linha.Substring(4).Trim()
                    });

                    continue;
                }

                // Citação
                if (linha.StartsWith("> "))
                {
                    AdicionarLista();

                    blocos.Add(new BlogContentBlock
                    {
                        Type = BlogBlockType.Quote,
                        Text = linha.Substring(2).Trim()
                    });

                    continue;
                }

                // Dica
                if (linha.StartsWith("[DICA]", StringComparison.OrdinalIgnoreCase))
                {
                    AdicionarLista();

                    blocos.Add(new BlogContentBlock
                    {
                        Type = BlogBlockType.Tip,
                        Text = linha.Substring(6).Trim()
                    });

                    continue;
                }

                // Imagem
                // Exemplo:
                // [IMAGEM] https://site.com/imagem.jpg
                if (linha.StartsWith("[IMAGEM]", StringComparison.OrdinalIgnoreCase))
                {
                    AdicionarLista();

                    var imagem = linha.Substring(8).Trim();

                    blocos.Add(new BlogContentBlock
                    {
                        Type = BlogBlockType.Image,
                        ImageUrl = imagem
                    });

                    continue;
                }

                // Linha divisória
                if (linha == "---")
                {
                    AdicionarLista();

                    blocos.Add(new BlogContentBlock
                    {
                        Type = BlogBlockType.Divider
                    });

                    continue;
                }

                // Lista
                if (linha.StartsWith("- "))
                {
                    itensLista.Add(linha.Substring(2).Trim());
                    continue;
                }

                AdicionarLista();

                // Texto normal
                blocos.Add(new BlogContentBlock
                {
                    Type = BlogBlockType.Paragraph,
                    Text = linha
                });
            }

            AdicionarLista();

            return blocos;
        }
    }
}