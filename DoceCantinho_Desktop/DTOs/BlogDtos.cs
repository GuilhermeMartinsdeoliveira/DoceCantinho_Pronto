using System;

namespace DoceCantinho.Desktop.DTOs
{
    public class BlogPostResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string Excerpt { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Tags { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public string AuthorRole { get; set; } = string.Empty;

        public string AuthorAvatar { get; set; } = string.Empty;

        public string AuthorBio { get; set; } = string.Empty;

        public DateTime PublishedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsPublished { get; set; }

        public bool Featured { get; set; }
    }

    public class CreateBlogPostDto
    {
        public string Title { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string Excerpt { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Tags { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public string AuthorRole { get; set; } = string.Empty;

        public string AuthorAvatar { get; set; } = string.Empty;

        public string AuthorBio { get; set; } = string.Empty;

        public DateTime PublishedAt { get; set; }

        public bool IsPublished { get; set; } = true;

        public bool Featured { get; set; }
    }

    public class UpdateBlogPostDto : CreateBlogPostDto
    {
    }
}