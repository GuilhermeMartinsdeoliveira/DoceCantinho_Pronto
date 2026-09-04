using System;

namespace DoceCantinho.Application.DTOs
{
    public class DoceDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        public double Preco { get; set; }

        // NOVO
        public int QuantidadeEstoque { get; set; }

        // NOVO
        public bool IsAtivo { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public bool IsFeatured { get; set; }

        public bool IsRecomendado { get; set; }

        public DateTime CreatedAt { get; set; }
    }


    public class CreateDoceDto
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        public double Preco { get; set; }

        // NOVO
        public int QuantidadeEstoque { get; set; }

        // NOVO
        public bool IsAtivo { get; set; } = true;

        public int CategoryId { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsRecomendado { get; set; }
    }


    public class UpdateDoceDto
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        public double Preco { get; set; }

        // NOVO
        public int QuantidadeEstoque { get; set; }

        // NOVO
        public bool IsAtivo { get; set; }

        public int CategoryId { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsRecomendado { get; set; }
    }
}