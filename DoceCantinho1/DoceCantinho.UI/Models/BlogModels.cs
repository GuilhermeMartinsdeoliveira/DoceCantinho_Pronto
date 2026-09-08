using System;
using System.Collections.Generic;
using System.Linq;

namespace DoceCantinho.UI.Models
{
    /// <summary>
    /// Tipos de blocos de conteúdo que um post de blog pode ter.
    /// Isso permite montar artigos "ricos" (com títulos, imagens, citações, listas, dicas)
    /// sem precisar de um editor WYSIWYG guardando HTML cru no banco.
    /// </summary>
    public enum BlogBlockType
    {
        Paragraph,
        Heading,
        SubHeading,
        Quote,
        List,
        Image,
        Tip,
        Divider
    }

    /// <summary>
    /// Um bloco de conteúdo dentro do corpo do artigo.
    /// </summary>
    public class BlogContentBlock
    {
        public BlogBlockType Type { get; set; }
        public string? Text { get; set; }
        public List<string>? Items { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageCaption { get; set; }
        public string? Author { get; set; }

        public static BlogContentBlock H(string text) => new() { Type = BlogBlockType.Heading, Text = text };
        public static BlogContentBlock H2(string text) => new() { Type = BlogBlockType.SubHeading, Text = text };
        public static BlogContentBlock P(string text) => new() { Type = BlogBlockType.Paragraph, Text = text };
        public static BlogContentBlock Quote(string text, string? author = null) => new() { Type = BlogBlockType.Quote, Text = text, Author = author };
        public static BlogContentBlock Ul(params string[] items) => new() { Type = BlogBlockType.List, Items = items.ToList() };
        public static BlogContentBlock Img(string url, string? caption = null) => new() { Type = BlogBlockType.Image, ImageUrl = url, ImageCaption = caption };
        public static BlogContentBlock Tip(string text) => new() { Type = BlogBlockType.Tip, Text = text };
        public static BlogContentBlock Hr() => new() { Type = BlogBlockType.Divider };
    }

    /// <summary>
    /// ViewModel completo de um post do blog — capa, metadados, SEO/leitura e corpo do artigo.
    /// </summary>
    public class BlogPostViewModel
    {
        public string Slug { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Excerpt { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();
        public DateTime PublishedAt { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorRole { get; set; } = string.Empty;
        public string AuthorAvatar { get; set; } = "/imagens/autores/confeiteira.jpg";
        public string AuthorBio { get; set; } = string.Empty;
        public bool Featured { get; set; }
        public List<BlogContentBlock> Content { get; set; } = new();

        /// <summary>Tempo estimado de leitura, calculado a partir da quantidade de texto do artigo.</summary>
        public int ReadingTimeMinutes
        {
            get
            {
                var words = Content
                    .Where(b => !string.IsNullOrWhiteSpace(b.Text))
                    .Sum(b => b.Text!.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length);
                words += Excerpt.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                var minutes = (int)Math.Ceiling(words / 180.0); // ~180 palavras por minuto
                return Math.Max(minutes, 2);
            }
        }

        /// <summary>Gera automaticamente o índice ("sumário") do artigo a partir dos títulos (H2).</summary>
        public List<TocItem> TableOfContents =>
            Content.Where(b => b.Type == BlogBlockType.Heading && !string.IsNullOrWhiteSpace(b.Text))
                   .Select(b => new TocItem { Text = b.Text!, AnchorId = Slugify(b.Text!) })
                   .ToList();

        public static string Slugify(string text)
        {
            var s = text.ToLowerInvariant().Trim();
            s = s.Replace("á", "a").Replace("à", "a").Replace("ã", "a").Replace("â", "a")
                 .Replace("é", "e").Replace("ê", "e")
                 .Replace("í", "i")
                 .Replace("ó", "o").Replace("ô", "o").Replace("õ", "o")
                 .Replace("ú", "u").Replace("ü", "u")
                 .Replace("ç", "c");
            var chars = s.Select(c => char.IsLetterOrDigit(c) ? c : '-').ToArray();
            var slug = new string(chars);
            while (slug.Contains("--")) slug = slug.Replace("--", "-");
            return slug.Trim('-');
        }
    }

    public class TocItem
    {
        public string Text { get; set; } = string.Empty;
        public string AnchorId { get; set; } = string.Empty;
    }

    public class BlogIndexViewModel
    {
        public IEnumerable<BlogPostViewModel> Posts { get; set; } = new List<BlogPostViewModel>();
        public BlogPostViewModel? FeaturedPost { get; set; }
        public IEnumerable<string> Categories { get; set; } = new List<string>();
        public string? SelectedCategory { get; set; }
    }

    public class BlogDetailsViewModel
    {
        public BlogPostViewModel Post { get; set; } = new();
        public IEnumerable<BlogPostViewModel> RelatedPosts { get; set; } = new List<BlogPostViewModel>();
    }
}
