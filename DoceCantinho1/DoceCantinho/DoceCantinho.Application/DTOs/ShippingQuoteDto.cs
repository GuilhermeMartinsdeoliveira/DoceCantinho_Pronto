namespace DoceCantinho.Application.DTOs
{
    public class ShippingQuoteDto
    {
        public string OriginCep { get; set; } = string.Empty;
        public string DestinationCep { get; set; } = string.Empty;
        public decimal ShippingPrice { get; set; }
        public int EstimatedDays { get; set; }
        public double EstimatedDistanceKm { get; set; }
        public string Method { get; set; } = "Simulado";
    }
}
