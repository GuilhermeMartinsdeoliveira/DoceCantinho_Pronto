using DoceCantinho.Application.DTOs;

namespace DoceCantinho.UI.ViewModels
{
    public class CarrinhoCheckoutViewModel
    {
        public CarrinhoSessao Carrinho { get; set; } = new();
        public CheckoutProfileDto? CheckoutProfile { get; set; }
        public ShippingQuoteDto? ShippingQuote { get; set; }
        public IEnumerable<DoceDto> RecommendedProducts { get; set; } = new List<DoceDto>();
        public bool IsAuthenticated { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public decimal Subtotal => Carrinho?.Total ?? 0m;
        public decimal Frete => ShippingQuote?.ShippingPrice ?? 0m;
        public decimal Total => Subtotal + Frete;
    }
}
