using DoceCantinho.Application.DTOs;

namespace DoceCantinho.Application.Interfaces
{
    public interface IShippingService
    {
        Task<ShippingQuoteDto> CalculateAsync(string originCep, string destinationCep);
    }
}
