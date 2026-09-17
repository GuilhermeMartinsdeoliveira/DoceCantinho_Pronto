// =============================================================================
// SenacDoces.Desktop - DTOs/DoceDtos.cs
// =============================================================================
//  CONCEITO: DTOs de Doces do Desktop
//
// Estes DTOs espelham os contratos da API de Doces:
//   GET    /api/doces         retorna lista de DoceResponseDto
//   GET    /api/doces/{id}    retorna DoceResponseDto
//   POST   /api/doces         recebe CreateDoceDto
//   PUT    /api/doces/{id}    recebe UpdateDoceDto
//   DELETE /api/doces/{id}    sem corpo
//
// IMPORTANTE: As propriedades devem ter os MESMOS NOMES que os campos JSON
// retornados pela API (System.Text.Json é case-insensitive por padrão).
// =============================================================================

namespace DoceCantinho.Desktop.DTOs
{
    /// <summary>
    /// DTO para representar um Doce retornado pela API.
    /// Usado para leitura (listagem, visualização).
    /// </summary>

    public class DoceResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string CoverImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }

        /// <summary>Nome da categoria (já resolvido pela API via JOIN)</summary>
        public string CategoryName { get; set; } = string.Empty;

        public bool IsFeatured { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// DTO para criação de um novo Doce.
    /// Enviado no corpo do POST /api/doces.
    /// </summary>
    public class CreateDoceDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string CoverImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public bool IsFeatured { get; set; }
    }

    /// <summary>
    /// DTO para atualização de um Doce existente.
    /// Enviado no corpo do PUT /api/doces/{id}.
    /// </summary>
    public class UpdateDoceDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string CoverImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public bool IsFeatured { get; set; }
    }
}
