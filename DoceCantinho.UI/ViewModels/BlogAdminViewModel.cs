using System;
using System.ComponentModel.DataAnnotations;

namespace DoceCantinho.UI.ViewModels
{
    public class BlogAdminViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o título.")]
        [Display(Name = "Título")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o resumo.")]
        [Display(Name = "Resumo")]
        public string Excerpt { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o conteúdo.")]
        [Display(Name = "Conteúdo")]
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Imagem de capa")]
        public string? CoverImageUrl { get; set; }

        [Required(ErrorMessage = "Informe a categoria.")]
        [Display(Name = "Categoria")]
        public string Category { get; set; } = string.Empty;

        [Display(Name = "Tags")]
        public string? Tags { get; set; }

        [Required(ErrorMessage = "Informe o nome do autor.")]
        [Display(Name = "Autor")]
        public string AuthorName { get; set; } = string.Empty;

        [Display(Name = "Cargo do autor")]
        public string? AuthorRole { get; set; }

        [Display(Name = "Foto do autor")]
        public string? AuthorAvatar { get; set; }

        [Display(Name = "Biografia do autor")]
        public string? AuthorBio { get; set; }

        [Display(Name = "Data de publicação")]
        [DataType(DataType.Date)]
        public DateTime PublishedAt { get; set; } = DateTime.Today;

        [Display(Name = "Publicado")]
        public bool IsPublished { get; set; } = true;

        [Display(Name = "Destacar artigo")]
        public bool Featured { get; set; }
    }
}