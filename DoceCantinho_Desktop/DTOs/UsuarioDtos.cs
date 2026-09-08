namespace DoceCantinho.Desktop.DTOs
{
    /// <summary>
    /// DTO para representar um Usuário retornado da API.
    /// </summary>
    public class UsuarioResponseDto
    {
        public string Id { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public List<string> Roles { get; set; } = new();

        public string Telefone { get; set; } = string.Empty;

        public string Logradouro { get; set; } = string.Empty;

        public string Numero { get; set; } = string.Empty;

        public string? Complemento { get; set; }

        public string Bairro { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public string Cep { get; set; } = string.Empty;

        public string PerfilPrincipal =>
            Roles.Contains("Admin") ? "Administrador" :
            Roles.Count > 0 ? string.Join(", ", Roles) : "Usuário Comum";
    }

    /// <summary>
    /// DTO para a criação de um novo Usuário.
    /// </summary>
    public class CreateUsuarioDto
    {
        public string Nome { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;

        public string Logradouro { get; set; } = string.Empty;

        public string Numero { get; set; } = string.Empty;

        public string? Complemento { get; set; }

        public string Bairro { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public string Cep { get; set; } = string.Empty;

        public string Role { get; set; } = "Usuário";
    }

    /// <summary>
    /// DTO para redefinição de senha de um Usuário.
    /// </summary>
    public class ResetPasswordDto
    {
        public string UserId { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO para atribuição/remoção de role (perfil de usuário).
    /// </summary>
    public class AssignRoleDto
    {
        public string UserId { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO para atualização de um Usuário.
    /// </summary>
    public class UpdateUsuarioDto
    {
        public string Nome { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public string Logradouro { get; set; } = string.Empty;

        public string Numero { get; set; } = string.Empty;

        public string? Complemento { get; set; }

        public string Bairro { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public string Cep { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}