namespace DoceCantinho.Application.DTOs
{
    public class CheckoutProfileDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;

        public string EnderecoCompleto
            => string.Join(", ", new[] { Logradouro, Numero, Bairro, Cidade, Estado, Cep }.Where(x => !string.IsNullOrWhiteSpace(x)));

        public bool TemEnderecoCompleto =>
            !string.IsNullOrWhiteSpace(Cep) &&
            !string.IsNullOrWhiteSpace(Logradouro) &&
            !string.IsNullOrWhiteSpace(Bairro) &&
            !string.IsNullOrWhiteSpace(Cidade) &&
            !string.IsNullOrWhiteSpace(Estado) &&
            !string.IsNullOrWhiteSpace(Numero);
    }
}
