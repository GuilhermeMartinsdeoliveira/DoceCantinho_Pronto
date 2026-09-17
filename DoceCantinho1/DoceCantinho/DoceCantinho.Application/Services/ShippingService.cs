using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;

namespace DoceCantinho.Application.Services
{
    public class ShippingService : IShippingService
    {
        public Task<ShippingQuoteDto> CalculateAsync(string originCep, string destinationCep)
        {
            var origin = NormalizeCep(originCep);
            var destination = NormalizeCep(destinationCep);

            if (origin.Length != 8)
                throw new ArgumentException("CEP de origem inválido.", nameof(originCep));

            if (destination.Length != 8)
                throw new ArgumentException("CEP de destino inválido.", nameof(destinationCep));

            var originNumeric = long.Parse(origin);
            var destinationNumeric = long.Parse(destination);
            var distanceSeed = Math.Abs(originNumeric - destinationNumeric);

            var estimatedDistanceKm = Math.Max(1, (distanceSeed % 9000) / 100.0);

            decimal shippingPrice;
            int estimatedDays;

            if (estimatedDistanceKm <= 15)
            {
                shippingPrice = 12.90m;
                estimatedDays = 1;
            }
            else if (estimatedDistanceKm <= 50)
            {
                shippingPrice = 18.90m;
                estimatedDays = 2;
            }
            else if (estimatedDistanceKm <= 150)
            {
                shippingPrice = 24.90m;
                estimatedDays = 3;
            }
            else if (estimatedDistanceKm <= 400)
            {
                shippingPrice = 34.90m;
                estimatedDays = 5;
            }
            else
            {
                shippingPrice = 49.90m;
                estimatedDays = 7;
            }

            return Task.FromResult(new ShippingQuoteDto
            {
                OriginCep = origin,
                DestinationCep = destination,
                ShippingPrice = shippingPrice,
                EstimatedDays = estimatedDays,
                EstimatedDistanceKm = Math.Round(estimatedDistanceKm, 1),
                Method = "Tabela simulada por CEP"
            });
        }

        private static string NormalizeCep(string cep)
            => new string((cep ?? string.Empty).Where(char.IsDigit).ToArray());
    }
}
