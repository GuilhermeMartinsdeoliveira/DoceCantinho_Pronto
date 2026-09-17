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
            public string Email { get; set; } = string.Empty;
            public string UserName { get; set; } = string.Empty;
            public List<string> Roles { get; set; } = new();
        }

        public class CreateUsuarioDto
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string ConfirmPassword { get; set; } = string.Empty;
            public string Role { get; set; } = "Usuário";
        }

        public class UpdateUsuarioDto
        {
            public string Email { get; set; } = string.Empty;
            public string? Password { get; set; }
            public string? ConfirmPassword { get; set; }
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
                        Email = user.Email ?? string.Empty,
                        UserName = user.UserName ?? string.Empty,
                        Roles = roles.ToList()
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
                Email = user.Email ?? string.Empty,
                UserName = user.UserName ?? string.Empty,
                Roles = roles.ToList()
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
                UserName = dto.Email,
                Email = dto.Email,
                EmailConfirmed = true,
                Cpf = string.Empty
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
                Roles = roles.ToList()
            };

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, response);
        }

        // =====================================================================
        // PUT /api/usuarios/{id} (Requer perfil Admin)
        // =====================================================================
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateUsuarioDto dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { message = $"Usuário com ID {id} não encontrado" });

            try
            {
                if (!string.IsNullOrWhiteSpace(dto.Email) &&
                    !string.Equals(dto.Email, user.Email, StringComparison.OrdinalIgnoreCase))
                {
                    var outroUsuario = await _userManager.FindByEmailAsync(dto.Email);
                    if (outroUsuario != null && outroUsuario.Id != user.Id)
                        return BadRequest(new { message = "Já existe um usuário com este e-mail." });

                    user.Email = dto.Email;
                    user.UserName = dto.Email;
                    user.NormalizedEmail = _userManager.NormalizeEmail(dto.Email);
                    user.NormalizedUserName = _userManager.NormalizeName(dto.Email);
                }

                // Senha em branco = mantém a senha atual (contrato combinado com o Desktop)
                if (!string.IsNullOrWhiteSpace(dto.Password))
                {
                    if (dto.Password != dto.ConfirmPassword)
                        return BadRequest(new { message = "As senhas não coincidem." });

                    var removeResult = await _userManager.RemovePasswordAsync(user);
                    if (!removeResult.Succeeded && removeResult.Errors.Any())
                    {
                        var errors = removeResult.Errors.Select(e => e.Description);
                        return BadRequest(new { message = "Erro ao atualizar senha.", errors });
                    }

                    var addPasswordResult = await _userManager.AddPasswordAsync(user, dto.Password);
                    if (!addPasswordResult.Succeeded)
                    {
                        var errors = addPasswordResult.Errors.Select(e => e.Description);
                        return BadRequest(new { message = "Erro ao atualizar senha.", errors });
                    }
                }

                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    var errors = updateResult.Errors.Select(e => e.Description);
                    return BadRequest(new { message = "Erro ao atualizar usuário.", errors });
                }

                if (!string.IsNullOrWhiteSpace(dto.Role))
                {
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    if (!currentRoles.Contains(dto.Role))
                    {
                        await GarantirRoleExisteAsync(dto.Role);

                        if (currentRoles.Any())
                            await _userManager.RemoveFromRolesAsync(user, currentRoles);

                        await _userManager.AddToRoleAsync(user, dto.Role);
                    }
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar usuário {id}: {ex.Message}");
                return StatusCode(500, "Erro ao atualizar usuário");
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
