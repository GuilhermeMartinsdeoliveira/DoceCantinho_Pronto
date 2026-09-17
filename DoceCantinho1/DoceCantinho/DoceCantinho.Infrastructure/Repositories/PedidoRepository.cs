using DoceCantinho.Domain.Entities;
using DoceCantinho.Domain.Interfaces;
using DoceCantinho.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoceCantinho.Infrastructure.Repositories
{
    /// <summary>
    /// Implementação do repositório de Pedidos usando Entity Framework Core
    /// para acessar o banco de dados.
    /// </summary>
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DoceCantinhoDbContext _context;

        public PedidoRepository(DoceCantinhoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os pedidos incluindo items relacionados (para Admin).
        /// Ordenados por data de criação (mais recentes primeiro).
        /// </summary>
        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos
                .Include(p => p.Items)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna todos os pedidos de um usuário específico.
        /// Usado para usuários comuns visualizarem seus próprios pedidos.
        /// </summary>
        public async Task<IEnumerable<Pedido>> GetByUserIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return Enumerable.Empty<Pedido>();

            return await _context.Pedidos
                .Include(p => p.Items)
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna um pedido específico pelo ID, incluindo items.
        /// </summary>
        public async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _context.Pedidos
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Adiciona um novo pedido ao banco de dados.
        /// Persiste tanto o pedido quanto seus items associados.
        /// </summary>
        public async Task AddAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um pedido existente no banco de dados.
        /// </summary>
        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove um pedido do banco de dados pelo ID.
        /// Também remove os items associados (cascata).
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var pedido = await GetByIdAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retorna a contagem total de pedidos no banco.
        /// </summary>
        public async Task<int> CountAsync()
        {
            return await _context.Pedidos.CountAsync();
        }

        /// <summary>
        /// Retorna a contagem de pedidos de um usuário específico.
        /// </summary>
        public async Task<int> CountByUserIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return 0;

            return await _context.Pedidos.CountAsync(p => p.UserId == userId);
        }
    }
}
