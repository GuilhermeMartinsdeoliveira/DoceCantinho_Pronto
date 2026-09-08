using DoceCantinho.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

// =============================================================================
// DoceCantinho.Application - Interface IPedidoService
// =============================================================================
// 🔪 CONCEITO IMPORTANTE: Service Layer (Camada de Serviço)
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
    /// Contrato de serviço de Pedidos.
    /// Define as operações de negócio disponíveis para pedidos.
    /// </summary>
    public interface IPedidoService
    {
        /// <summary>
        /// Retorna todos os pedidos (apenas Admin).
        /// </summary>
        Task<IEnumerable<PedidoDto>> GetAllAsync();

        /// <summary>
        /// Retorna todos os pedidos de um usuário específico.
        /// Usado para usuários comuns visualizarem seus próprios pedidos.
        /// </summary>
        Task<IEnumerable<PedidoDto>> GetByUserIdAsync(string userId);

        /// <summary>
        /// Retorna um pedido específico pelo ID.
        /// </summary>
        Task<PedidoDto?> GetByIdAsync(int id);

        /// <summary>
        /// Cria um novo pedido.
        /// </summary>
        Task<PedidoDto> CreateAsync(CreatePedidoDto dto, string userId);

        /// <summary>
        /// Atualiza um pedido existente.
        /// </summary>
        Task<PedidoDto?> UpdateAsync(int id, UpdatePedidoDto dto);

        /// <summary>
        /// Atualiza apenas o status de um pedido.
        /// </summary>
        Task<PedidoDto?> UpdateStatusAsync(int id, string newStatus);

        /// <summary>
        /// Deleta um pedido.
        /// </summary>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Retorna a contagem total de pedidos.
        /// </summary>
        Task<int> CountAsync();

        /// <summary>
        /// Retorna a contagem de pedidos de um usuário.
        /// </summary>
        Task<int> CountByUserIdAsync(string userId);
    }
}
