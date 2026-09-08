// =============================================================================
// DoceCantinho.Domain - Interface IPedidoRepository
// =============================================================================
// 🔤 CONCEITO IMPORTANTE:
// Uma INTERFACE define um CONTRATO - ela diz O QUE deve ser feito,
// mas NÃO diz COMO fazer. A implementação fica em outra camada.
//
// Isso é fundamental na arquitetura em camadas:
// - O Domain DEFINE a interface (o contrato)
// - O Infrastructure IMPLEMENTA a interface (o código real)
// - Isso permite trocar a implementação sem alterar o resto do sistema
// =============================================================================

using DoceCantinho.Domain.Entities;

namespace DoceCantinho.Domain.Interfaces
{
    /// <summary>
    /// Contrato do repositório de Pedidos.
    /// Define as operações disponíveis para acessar dados de pedidos.
    /// </summary>
    public interface IPedidoRepository
    {
        /// <summary>
        /// Retorna todos os pedidos existentes no banco de dados.
        /// Apenas para Admin.
        /// </summary>
        Task<IEnumerable<Pedido>> GetAllAsync();

        /// <summary>
        /// Retorna todos os pedidos de um usuário específico.
        /// Usado para usuários comuns visualizarem seus próprios pedidos.
        /// </summary>
        Task<IEnumerable<Pedido>> GetByUserIdAsync(string userId);

        /// <summary>
        /// Busca um pedido específico pelo seu Id.
        /// Retorna null (nulo) se não encontrar.
        /// </summary>
        Task<Pedido?> GetByIdAsync(int id);

        /// <summary>
        /// Adiciona um novo pedido ao banco de dados.
        /// </summary>
        Task AddAsync(Pedido pedido);

        /// <summary>
        /// Atualiza um pedido existente no banco de dados.
        /// </summary>
        Task UpdateAsync(Pedido pedido);

        /// <summary>
        /// Remove um pedido do banco de dados com base no ID.
        /// </summary>
        Task DeleteAsync(int id);

        /// <summary>
        /// Retorna a contagem total de pedidos no banco.
        /// </summary>
        Task<int> CountAsync();

        /// <summary>
        /// Retorna a contagem de pedidos de um usuário específico.
        /// </summary>
        Task<int> CountByUserIdAsync(string userId);
    }
}
