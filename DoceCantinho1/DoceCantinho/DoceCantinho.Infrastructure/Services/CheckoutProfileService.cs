using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using DoceCantinho.Infrastructure.Context;
using DoceCantinho.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DoceCantinho.Infrastructure.Services
{
    public class CheckoutProfileService : ICheckoutProfileService
    {
        private readonly DoceCantinhoDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutProfileService(DoceCantinhoDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<CheckoutProfileDto?> GetByUserIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return null;

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return null;

            return new CheckoutProfileDto
            {
                UserId = user.Id,
                Email = user.Email ?? string.Empty,
                Cpf = user.Cpf ?? string.Empty,
                Logradouro = user.Logradouro ?? string.Empty,
                Bairro = user.Bairro ?? string.Empty,
                Cidade = user.Cidade ?? string.Empty,
                Estado = user.Estado ?? string.Empty,
                Numero = user.Numero ?? string.Empty,
                Cep = user.Cep ?? string.Empty
            };
        }
    }
}
