// =============================================================================
// DoceCantinho.Desktop - DTOs/AuthDtos.cs
// =============================================================================

using System;
using System.Collections.Generic;

namespace DoceCantinho.Desktop.DTOs
{
    /// <summary>
    /// DTO para envio das credenciais de login para a API.
    /// </summary>
    public class LoginRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO para registro de novo usuário.
    /// </summary>
    public class RegisterRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO do usuário autenticado retornado pela API.
    /// Deve espelhar o UserDto da API.
    /// </summary>
    public class UserResponseDto
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
        public string? FotoPerfil { get; set; }

        public string Cep { get; set; } = string.Empty;

        public bool IsAdmin =>
            Roles.Contains("Admin", StringComparer.OrdinalIgnoreCase);

        public string PerfilPrincipal =>
            IsAdmin
                ? "Administrador"
                : Roles.Count > 0
                    ? string.Join(", ", Roles)
                    : "Usuário Comum";
    }

    /// <summary>
    /// DTO enviado para atualização do perfil do usuário autenticado.
    /// Corresponde ao UpdateProfileDto da AuthController da API.
    /// </summary>
    public class UpdateProfileRequestDto
    {
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Logradouro { get; set; } = string.Empty;

        public string Numero { get; set; } = string.Empty;

        public string? Complemento { get; set; }

        public string Bairro { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public string Cep { get; set; } = string.Empty;
        public string? FotoPerfil { get; set; }

        public string? CurrentPassword { get; set; }

        public string? NewPassword { get; set; }

        public string? ConfirmPassword { get; set; }
    }
}