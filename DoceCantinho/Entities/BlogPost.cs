using System;
using System.ComponentModel.DataAnnotations;

namespace DoceCantinho.Domain.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Slug { get; set; } = string.Empty;

        [Required]
        [MaxLength(2000)]
        public string Excerpt { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [MaxLength(500)]
        public string CoverImageUrl { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Category { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Tags { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string AuthorName { get; set; } = string.Empty;

        [MaxLength(150)]
        public string AuthorRole { get; set; } = string.Empty;

        [MaxLength(500)]
        public string AuthorAvatar { get; set; } =
            "/imagens/autores/confeiteira.jpg";

        [MaxLength(1000)]
        public string AuthorBio { get; set; } = string.Empty;

        public DateTime PublishedAt { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public bool IsPublished { get; set; } = true;

        public bool Featured { get; set; } = false;
    }
}