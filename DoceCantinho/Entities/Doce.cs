using DoceCantinho.Domain.Entities;
using System;

namespace DoceCantinho.Domain.Interfaces
{
    public class Doce
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        public double Preco { get; set; }

        // QUANTIDADE DISPONÍVEL NO ESTOQUE
        public int QuantidadeEstoque { get; set; }

        public int CategoryId { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsRecomendado { get; set; }

        // STATUS DO DOCE
        public bool IsAtivo { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual Category? Category { get; set; }
    }
}