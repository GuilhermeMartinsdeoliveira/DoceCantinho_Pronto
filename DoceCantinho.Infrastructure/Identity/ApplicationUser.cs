using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DoceCantinho.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(14)]
        public string Cpf { get; set; } = string.Empty;

        [StringLength(100)]
        public string Logradouro { get; set; } = string.Empty;

        [StringLength(20)]
        public string Numero { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Complemento { get; set; }

        [StringLength(50)]
        public string Bairro { get; set; } = string.Empty;

        [StringLength(50)]
        public string Cidade { get; set; } = string.Empty;

        [StringLength(2)]
        public string Estado { get; set; } = string.Empty;

        [StringLength(9)]
        public string Cep { get; set; } = string.Empty;
    }
}