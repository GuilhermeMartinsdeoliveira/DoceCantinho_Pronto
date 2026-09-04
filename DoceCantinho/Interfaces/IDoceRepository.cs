// =============================================================================
// DoceCantinho.Domain - Interface IDoceRepository
// =============================================================================
// 📌 CONCEITO IMPORTANTE:
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
    /// Contrato do repositório de Games.
    /// Define as operações disponíveis para acessar dados de games.
    /// </summary>
    public interface IDoceRepository
    {
        /// <summary>
        /// Retorna todos os games existentes no banco de dados.
        /// </summary>
        Task<IEnumerable<Doce>> GetAllAsync();

        /// <summary>
        /// Busca um game específico pelo seu Id.
        /// Retorna null (nulo) se não encontrar.
        /// </summary>
        Task<Doce?> GetByIdAsync(int id);

        /// <summary>
        /// Retorna apenas os games marcados como destaque (IsFeatured = true).
        /// </summary>
        Task<IEnumerable<Doce>> GetFeaturedAsync();

        /// <summary>
        /// Retorna produtos recomendados para cross-selling.
        /// </summary>
        Task<IEnumerable<Doce>> GetRecommendedAsync(int count = 3);

        /// <summary>
        /// Retorna todos os games de uma categoria específica.
        /// </summary>
        Task<IEnumerable<Doce>> GetByCategoryAsync(int categoryId);

        /// <summary>
        /// Adiciona um novo game ao banco de dados.
        /// </summary>
        Task AddAsync(Doce doce);

        /// <summary>
        /// Atualiza os dados de um game existente.
        /// </summary>
        Task UpdateAsync(Doce doce);

        /// <summary>
        /// Remove um game do banco de dados.
        /// </summary>
        Task DeleteAsync(int id);

        /// <summary>
        /// Retorna o total de games cadastrados.
        /// </summary>
        Task<int> CountAsync();
    }
}