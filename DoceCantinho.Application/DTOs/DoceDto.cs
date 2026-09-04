using System;
using System.Collections.Generic;
using System.Text;

// =============================================================================
// Doce.Application - DTO GameDto
// =============================================================================
// 📌 CONCEITO IMPORTANTE: DTO (Data Transfer Object)
// Um DTO é um objeto usado para TRANSFERIR dados entre camadas.
// Ele contém apenas os dados necessários, sem lógica de negócio.
//
// Por que usar DTOs ao invés de enviar a Entidade diretamente?
// 1. Segurança: evita expor dados internos do banco
// 2. Flexibilidade: permite enviar apenas os campos necessários
// 3. Desacoplamento: a API não depende da estrutura do banco
// =============================================================================

namespace DoceCantinho.Application.DTOs
{
    public class DoceDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public double Preco { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty; // Nome da categoria (ex: "Chocolate", "Bombom")
        public bool IsFeatured { get; set; }
        public bool IsRecomendado { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateDoceDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsRecomendado { get; set; }
        public double Preco { get; set; }
    }

    public class UpdateDoceDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string CoverImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsRecomendado { get; set; }
        public double Preco { get; set; }
    }
}
