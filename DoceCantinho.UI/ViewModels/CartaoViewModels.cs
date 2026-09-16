using System.ComponentModel.DataAnnotations;

namespace DoceCantinho.UI.ViewModels
{
    public class CartaoCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do titular.")]
        [StringLength(120)]
        [Display(Name = "Nome no cartão")]
        public string NomeTitular { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o número do cartão.")]
        [Display(Name = "Número do cartão")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "Selecione o tipo do cartão.")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; } = "Credito";

        [Required(ErrorMessage = "Selecione a bandeira.")]
        [StringLength(30)]
        [Display(Name = "Bandeira")]
        public string Bandeira { get; set; } = "Visa";

        [Range(1, 12, ErrorMessage = "Informe um mês entre 01 e 12.")]
        [Display(Name = "Mês")]
        public int MesValidade { get; set; }

        [Range(2026, 2100, ErrorMessage = "Informe um ano de validade válido.")]
        [Display(Name = "Ano")]
        public int AnoValidade { get; set; }
    }

    public class CartaoResumoViewModel
    {
        public int Id { get; set; }
        public string NomeTitular { get; set; } = string.Empty;
        public string Ultimos4 { get; set; } = string.Empty;
        public string Bandeira { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int MesValidade { get; set; }
        public int AnoValidade { get; set; }

        public string TipoFormatado =>
            Tipo.Equals("Debito", StringComparison.OrdinalIgnoreCase)
                ? "Débito"
                : "Crédito";

        public string Validade => $"{MesValidade:00}/{AnoValidade}";
    }
}
