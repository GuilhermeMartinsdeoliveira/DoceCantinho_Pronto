using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DoceCantinho.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(14)]
        public string Cpf { get; set; }

        [StringLength(100)]
        public string Logradouro { get; set; }

        [StringLength(50)]
        public string Bairro { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }

        [StringLength(20)]
        public string Numero { get; set; }

        [StringLength(9)]
        public string Cep { get; set; }
    }
}
