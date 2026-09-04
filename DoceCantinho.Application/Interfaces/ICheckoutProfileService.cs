using DoceCantinho.Application.DTOs;

namespace DoceCantinho.Application.Interfaces
{
    public interface ICheckoutProfileService
    {
        Task<CheckoutProfileDto?> GetByUserIdAsync(string userId);
    }
}
