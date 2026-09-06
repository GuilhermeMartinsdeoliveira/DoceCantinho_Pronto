// =============================================================================
// DoceCantinho.API - Controllers/UsuariosController.cs
// =============================================================================
// 📌 Este controller faltava na API. O app Desktop (UsuariosApiService) já
// chamava os endpoints /api/usuarios, /api/usuarios/{id} e
// /api/usuarios/perfis, mas como este controller não existia, toda
// requisição retornava 404 Not Found.
// =============================================================================

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DoceCantinho.Infrastructure.Identity;

namespace DoceCantinho.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Requer estar autenticado (cookie) para qualquer ação
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<UsuariosController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        // =====================================================================
        // DTOs (mantidos aqui dentro, seguindo o mesmo padrão já usado no
        // OrdersController.cs deste projeto)
        // =====================================================================

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
    }

    public class CreateUsuarioDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string? Complemento { get; set; }
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;

        public string Role { get; set; } = "Usuário";
    }

    public class UpdateUsuarioDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string Telefone  { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string? Complemento { get; set; }
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
        // =====================================================================
        // GET /api/usuarios
        // =====================================================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDto>>> GetAll()
        {
            try
            {
                var lista = new List<UsuarioResponseDto>();

                foreach (var user in _userManager.Users.ToList())
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    lista.Add(new UsuarioResponseDto
                    {
                        Id = user.Id,

                        Nome = user.Nome,

                        Email = user.Email ?? string.Empty,

                        UserName = user.UserName ?? string.Empty,

                        Roles = roles.ToList(),

                        Telefone = user.PhoneNumber ?? string.Empty,

                        Logradouro = user.Logradouro,

                        Numero = user.Numero,

                        Complemento = user.Complemento,

                        Bairro = user.Bairro,

                        Cidade = user.Cidade,

                        Estado = user.Estado,

                        Cep = user.Cep
                    });
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter usuários: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // =====================================================================
        // GET /api/usuarios/perfis
        // IMPORTANTE: esta rota precisa vir ANTES de GET("{id}") na ordem de
        // registro de atributos para não ser interpretada como um :id.
        // (No ASP.NET Core, rotas literais têm prioridade automática sobre
        // rotas com parâmetro, então não há conflito, mas mantemos aqui por
        // clareza de leitura.)
        // =====================================================================
        [HttpGet("perfis")]
        public ActionResult<IEnumerable<string>> GetPerfis()
        {
            var roles = _roleManager.Roles
                .Select(r => r.Name)
                .Where(n => !string.IsNullOrEmpty(n))
                .ToList();

            return Ok(roles);
        }

        // =====================================================================
        // GET /api/usuarios/{id}
        // =====================================================================
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDto>> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { message = $"Usuário com ID {id} não encontrado" });

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(new UsuarioResponseDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email ?? string.Empty,
                UserName = user.UserName ?? string.Empty,
                Roles = roles.ToList(),
                Telefone = user.PhoneNumber ?? string.Empty,
                Logradouro = user.Logradouro,
                Numero = user.Numero,
                Complemento = user.Complemento,
                Bairro = user.Bairro,
                Cidade = user.Cidade,
                Estado = user.Estado,
                Cep = user.Cep
            });
        }

        // =====================================================================
        // POST /api/usuarios (Requer perfil Admin)
        // =====================================================================
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UsuarioResponseDto>> Create([FromBody] CreateUsuarioDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                return BadRequest(new { message = "O e-mail é obrigatório." });

            if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password != dto.ConfirmPassword)
                return BadRequest(new { message = "As senhas não coincidem." });

            var existente = await _userManager.FindByEmailAsync(dto.Email);
            if (existente != null)
                return BadRequest(new { message = "Já existe um usuário com este e-mail." });

            var user = new ApplicationUser
            {
                Nome = dto.Nome.Trim(),
                UserName = dto.Email.Trim(),
                Email = dto.Email.Trim(),
                PhoneNumber = dto.Telefone.Trim(),
                Logradouro = dto.Logradouro.Trim(),
                Numero = dto.Numero.Trim(),
                Complemento = string.IsNullOrWhiteSpace(dto.Complemento)
                    ? null
                    : dto.Complemento.Trim(),
                Bairro = dto.Bairro.Trim(),
                Cidade = dto.Cidade.Trim(),
                Estado = dto.Estado.Trim().ToUpper(),
                Cep = dto.Cep.Trim()
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { message = "Erro ao criar usuário.", errors });
            }

            var role = string.IsNullOrWhiteSpace(dto.Role) ? "Usuário" : dto.Role;
            await GarantirRoleExisteAsync(role);
            await _userManager.AddToRoleAsync(user, role);

            var roles = await _userManager.GetRolesAsync(user);
            var response = new UsuarioResponseDto
            {
                Id = user.Id,
                Email = user.Email!,
                UserName = user.UserName!,
                Roles = roles.ToList(),

                Telefone = user.PhoneNumber ?? string.Empty,

                Logradouro = user.Logradouro ?? string.Empty,
                Numero = user.Numero ?? string.Empty,
                Complemento = user.Complemento,
                Bairro = user.Bairro ?? string.Empty,
                Cidade = user.Cidade ?? string.Empty,
                Estado = user.Estado ?? string.Empty,
                Cep = user.Cep ?? string.Empty
            };

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, response);
        }

        // =====================================================================
        // PUT /api/usuarios/{id} (Requer perfil Admin)
        // =====================================================================
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(
            string id,
            [FromBody] UpdateUsuarioDto dto)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound(new
                {
                    message = $"Usuário com ID {id} não encontrado"
                });

            try
            {
                // E-mail
                if (!string.IsNullOrWhiteSpace(dto.Email) &&
                    !string.Equals(
                        user.Email,
                        dto.Email,
                        StringComparison.OrdinalIgnoreCase))
                {
                    user.Email = dto.Email;
                    user.UserName = dto.Email;
                }

                // Dados pessoais
                user.Nome = dto.Nome;
                user.PhoneNumber = dto.Telefone;

                // Endereço
                user.Logradouro = dto.Logradouro;
                user.Numero = dto.Numero;
                user.Complemento = dto.Complemento;
                user.Bairro = dto.Bairro;
                user.Cidade = dto.Cidade;
                user.Estado = dto.Estado;
                user.Cep = dto.Cep;

                // Senha
                if (!string.IsNullOrWhiteSpace(dto.Password))
                {
                    if (dto.Password != dto.ConfirmPassword)
                    {
                        return BadRequest(new
                        {
                            message = "As senhas não coincidem."
                        });
                    }

                    var token =
                        await _userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResult =
                        await _userManager.ResetPasswordAsync(
                            user,
                            token,
                            dto.Password);

                    if (!passwordResult.Succeeded)
                    {
                        return BadRequest(new
                        {
                            message = string.Join(
                                "; ",
                                passwordResult.Errors.Select(e => e.Description))
                        });
                    }
                }

                var updateResult = await _userManager.UpdateAsync(user);

                if (!updateResult.Succeeded)
                {
                    return BadRequest(new
                    {
                        message = string.Join(
                            "; ",
                            updateResult.Errors.Select(e => e.Description))
                    });
                }

                // Perfil
                if (!string.IsNullOrWhiteSpace(dto.Role))
                {
                    await GarantirRoleExisteAsync(dto.Role);

                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Count > 0)
                        await _userManager.RemoveFromRolesAsync(user, roles);

                    await _userManager.AddToRoleAsync(user, dto.Role);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Erro ao atualizar usuário {Id}",
                    id);

                return StatusCode(
                    500,
                    new { message = "Erro interno do servidor." });
            }
        }

        // =====================================================================
        // DELETE /api/usuarios/{id} (Requer perfil Admin)
        // =====================================================================
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { message = $"Usuário com ID {id} não encontrado" });

            // Evita que o admin exclua a própria conta enquanto logado
            var currentUserId = _userManager.GetUserId(User);
            if (currentUserId == id)
                return BadRequest(new { message = "Você não pode excluir o próprio usuário logado." });

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { message = "Erro ao excluir usuário.", errors });
            }

            return NoContent();
        }

        // =====================================================================
        // AUXILIAR
        // =====================================================================
        private async Task GarantirRoleExisteAsync(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
