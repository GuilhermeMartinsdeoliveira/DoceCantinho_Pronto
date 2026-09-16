namespace DoceCantinho.Domain.Entities
{
    /// <summary>
    /// Cartão salvo pelo cliente para pagamentos demonstrativos.
    /// Por segurança, nunca armazena o número completo nem o CVV.
    /// </summary>
    public class Cartao
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string NomeTitular { get; set; } = string.Empty;

        public string Ultimos4 { get; set; } = string.Empty;

        public string Bandeira { get; set; } = string.Empty;

        /// <summary>
        /// Credito ou Debito.
        /// </summary>
        public string Tipo { get; set; } = "Credito";

        public int MesValidade { get; set; }

        public int AnoValidade { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
