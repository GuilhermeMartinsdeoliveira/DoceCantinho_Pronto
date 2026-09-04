using DoceCantinho.Domain.Interfaces;
using DoceCantinho.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoceCantinho.Infrastructure.Repositories
{
    /// <summary>
    /// Implementação do repositório de Games usando o 
    /// Entity Framework Core para acessar o banco de dados.
    /// </summary>
    public class DoceRepository : IDoceRepository
    {
        private readonly DoceCantinhoDbContext _context;

        public DoceRepository(DoceCantinhoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os games incluindo categoria relacionada 
        /// por data de criação
        /// OBS: Include() = carrega dados de tabelas relacionadas
        /// </summary>
        /// <returns>
        /// Lista de Games
        /// </returns>
        public async Task<IEnumerable<Doce>> GetAllAsync()
        {
            return await _context.Doces
                .Include(g => g.Category) // Faz JOIN com a tabela Categories
                .OrderByDescending(g => g.CreatedAt) // Ordena por data de criação
                .ToListAsync();
        }

        /// <summary>
        /// Retorna um game por ID, incluindo a categoria relacionada
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Game com id específico.</returns>
        public async Task<Doce?> GetByIdAsync(int id)
        {
            return await _context.Doces
                .Include(g => g.Category) // Faz JOIN com a tabela Categories
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        /// <summary>
        /// Retorna apenas os games marcados como destaque
        /// OBS: WHERE() = filtra os dados com base em uma condição(Equivalente ao WHERE do SQL)
        /// </summary>
        public async Task<IEnumerable<Doce>> GetFeaturedAsync()
        {
            return await _context.Doces
                .AsNoTracking()
                .Include(g => g.Category)
                .Where(g => g.IsFeatured)
                .OrderByDescending(g => g.CreatedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna produtos recomendados para cross-selling.
        /// Prioriza os marcados com IsRecomendado = true; se não houver, devolve itens aleatórios.
        /// </summary>
        public async Task<IEnumerable<Doce>> GetRecommendedAsync(int count = 3)
        {
            var recommended = await _context.Doces
                .AsNoTracking()
                .Include(g => g.Category)
                .Where(g => g.IsRecomendado)
                .ToListAsync();

            if (recommended.Any())
                return recommended.OrderBy(_ => Guid.NewGuid()).Take(count).ToList();

            var fallback = await _context.Doces
                .AsNoTracking()
                .Include(g => g.Category)
                .OrderByDescending(g => g.CreatedAt)
                .Take(Math.Max(count, 1) * 3)
                .ToListAsync();

            return fallback.OrderBy(_ => Guid.NewGuid()).Take(count).ToList();
        }

        /// <summary>
        ///  Retorna todos os games de uma categoria especifica   
        /// </summary>
        public async Task<IEnumerable<Doce>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Doces
                .Include(g => g.Category) // Faz JOIN com a tabela Categories
                .Where(g => g.CategoryId == categoryId) // Filtra apenas os games em destaque
                .ToListAsync();
        }

        /// <summary>
        /// Adiciona um novo game ao banco de dados e salva as alterações.
        /// OBS: AddAsync() = adiciona um novo registro ao banco de dados de forma assíncrona
        /// OBS: SaveChangesAsync() = equivalente ao INSERT, salva as alterações feitas no contexto do banco de dados de forma assíncrona
        /// </summary>
        /// <param name="doce"></param>
        /// <returns></returns>
        public async Task AddAsync(Doce doce)
        {
            await _context.Doces.AddAsync(doce);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um game existente no banco de dados e salva as alterações.
        /// </summary>
        /// <param name="doce"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Doce doce)
        {
            _context.Doces.Update(doce); // o Update não necessita de await pois ele apenas marca a entidade como modificada, não executa uma operação no banco de dados imediatamente
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Remove um game do banco de dados com base no ID e salva as alterações.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var doce = await _context.Doces.FindAsync(id);
            if (doce != null)
            {
                _context.Doces.Remove(doce);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        ///  Retorna a contagem total de games no banco de dados.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountAsync()
        {
            return await _context.Doces.CountAsync();
        }



    }
}
