using DoceCantinho.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

// =============================================================================
// SenacGames.Application - Interface IGameService
// =============================================================================
// 📌 CONCEITO IMPORTANTE: Service Layer (Camada de Serviço)
// A camada Application contém os SERVIÇOS que orquestram as operações.
// Ela é a "ponte" entre os Controllers e os Repositories.
//
// Fluxo: Controller → Service → Repository → Banco de Dados
//
// O Service é responsável por:
// - Orquestrar chamadas ao repositório
// - Mapear Entidades para DTOs (e vice-versa)
// - Aplicar regras de aplicação (validações, etc.)
// =============================================================================

namespace DoceCantinho.Application.Interfaces
{

    /// <summary>
    /// Contrato de serviço de Games.
    /// Define as operações de negócio disponíveis para o game.
    /// </summary>
    public interface IDoceService
    {
        Task<IEnumerable<DoceDto>> GetAllAsync();
        Task<DoceDto?> GetByIdAsync(int id);
        Task<IEnumerable<DoceDto>> GetFeaturedAsync();
        Task<IEnumerable<DoceDto>> GetRecommendedAsync(int count = 3);
        Task<IEnumerable<DoceDto>> GetByCategoryAsync(int categoryId);
        Task<DoceDto> CreateAsync(CreateDoceDto dto);
        Task<DoceDto?> UpdateAsync(int id,UpdateDoceDto dto);
        Task<bool> DeleteAsync(int id);
        Task<int> CountAsync();
    }
}
