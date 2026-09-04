using System;

namespace DoceCantinho.Desktop.DTOs
{
    // ============================================================
    // DTO DE RESPOSTA DA API
    // ============================================================

    public class DoceResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        // manter tipo double para compatibilidade com outras DTOs do projeto
        public double Preco { get; set; }

        public string CategoryName { get; set; } = "";

        // id da categoria (necessário para forms e binding)
        public int CategoryId { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsAtivo { get; set; }

        public int QuantidadeEstoque { get; set; }

        public DateTime CreatedAt { get; set; }

        // usar o mesmo nome usado nas outras camadas (CoverImageUrl)
        public string CoverImageUrl { get; set; } = "";
    }


    // ============================================================
    // DTO PARA CRIAR DOCE
    // ============================================================

    public class CreateDoceDto
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // remover ReleaseYear (não aplicável) e manter CoverImageUrl consistente
        public string CoverImageUrl { get; set; } = string.Empty;

        // PREÇO
        public double Preco { get; set; }

        // RECOMENDADO (adicionado para parity com Application.DTOs)
        public bool IsRecomendado { get; set; }

        // ESTOQUE
        public int QuantidadeEstoque { get; set; }

        // STATUS
        public bool IsAtivo { get; set; } = true;

        // CATEGORIA
        public int CategoryId { get; set; }

        // DESTAQUE
        public bool IsFeatured { get; set; }
    }


    // ============================================================
    // DTO PARA ATUALIZAR DOCE
    // ============================================================

    public class UpdateDoceDto
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;

        // PREÇO
        public double Preco { get; set; }

        // RECOMENDADO
        public bool IsRecomendado { get; set; }

        // ESTOQUE
        public int QuantidadeEstoque { get; set; }

        // STATUS
        public bool IsAtivo { get; set; } = true;

        // CATEGORIA
        public int CategoryId { get; set; }

        // DESTAQUE
        public bool IsFeatured { get; set; }
    }
}