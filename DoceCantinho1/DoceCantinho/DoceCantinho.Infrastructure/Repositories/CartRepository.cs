using DoceCantinho.Domain.Interfaces;
using DoceCantinho.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DoceCantinho.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DoceCantinhoDbContext _context;

        public CartRepository(DoceCantinhoDbContext context)
        {
            _context = context;
        }

        public async Task<string?> GetCartJsonByUserIdAsync(string userId)
        {
            var entity = await _context.CartPersistences.FirstOrDefaultAsync(c => c.UserId == userId);
            return entity?.CartJson;
        }

        public async Task SaveCartJsonByUserIdAsync(string userId, string cartJson)
        {
            var entity = await _context.CartPersistences.FirstOrDefaultAsync(c => c.UserId == userId);
            if (entity == null)
            {
                entity = new DoceCantinho.Domain.Entities.CartPersistence
                {
                    UserId = userId,
                    CartJson = cartJson,
                    UpdatedAt = DateTime.UtcNow
                };
                await _context.CartPersistences.AddAsync(entity);
            }
            else
            {
                entity.CartJson = cartJson;
                entity.UpdatedAt = DateTime.UtcNow;
                _context.CartPersistences.Update(entity);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartByUserIdAsync(string userId)
        {
            var entity = await _context.CartPersistences.FirstOrDefaultAsync(c => c.UserId == userId);
            if (entity != null)
            {
                _context.CartPersistences.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
