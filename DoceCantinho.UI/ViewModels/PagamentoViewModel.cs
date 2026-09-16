using System.ComponentModel.DataAnnotations;

namespace DoceCantinho.UI.ViewModels
{
    public class PagamentoViewModel
    {
        [Required]
        public string PaymentMethod { get; set; } = "Pix";

        public string CardType { get; set; } = "Credit";

        public int Installments { get; set; } = 1;

        public string CardNumber { get; set; } = string.Empty;

        public string CardHolder { get; set; } = string.Empty;

        public string CardExpiration { get; set; } = string.Empty;

        public string CardCvv { get; set; } = string.Empty;
    }
}