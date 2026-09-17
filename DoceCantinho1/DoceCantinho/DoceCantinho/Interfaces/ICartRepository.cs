using System.Threading.Tasks;

namespace DoceCantinho.Domain.Interfaces
{
    public interface ICartRepository
    {
        Task<string?> GetCartJsonByUserIdAsync(string userId);
        Task SaveCartJsonByUserIdAsync(string userId, string cartJson);
        Task DeleteCartByUserIdAsync(string userId);
    }
}
