using System;
using System.Collections.Generic;

namespace DoceCantinho.Application.DTOs
{
    // ============================================================
    // LOGIN
    // ============================================================
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    // ============================================================
    // REGISTRO
    // ============================================================
    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    // ============================================================
    // USUÁRIO AUTENTICADO
    // ============================================================
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;
        public string? FotoPerfil { get; set; }

        public IList<string> Roles { get; set; } =
            new List<string>();

        public string Telefone { get; set; } = string.Empty;

        public string Logradouro { get; set; } = string.Empty;

        public string Numero { get; set; } = string.Empty;

        public string? Complemento { get; set; }

        public string Bairro { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public string Cep { get; set; } = string.Empty;

        // ========================================================
        // AUXILIAR PARA O DESKTOP
        // ========================================================
        public bool IsAdmin =>
            Roles.Contains(
                "Admin",
                StringComparer.OrdinalIgnoreCase);
    }
}