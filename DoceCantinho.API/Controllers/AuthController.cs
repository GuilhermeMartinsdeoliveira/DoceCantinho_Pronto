using DoceCantinho.Application.DTOs;
using DoceCantinho.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace DoceCantinho.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        public class UpdateProfileDto
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

        //UserManager e SignManager são serviços do Identity
        //UserManager: gerencia operações com usuários (criar, buscar...)
        //SignManager: gerencia operações de autenticação (login, logout...)
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Registra um novo usuário.
        /// POST /api/auth/register
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto dto)
        {
            //validação de senha
            if (dto.Password != dto.ConfirmPassword)
                return BadRequest(new { message = "As senhas não coincidem." });

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Cpf = "000.000.000-00",
                Logradouro = string.Empty,
                Bairro = string.Empty,
                Cidade = string.Empty,
                Estado = string.Empty,
                Numero = string.Empty,
                Cep = string.Empty
            };

            //Cria o usuário usando o UserManager
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(erros => erros.Description);
                return BadRequest(new { message = "Erro ao registrar usuário.", errors });
            }

            const string rolePadrao = "Usuário";
            if (!await _roleManager.RoleExistsAsync(rolePadrao))
            {
                await _roleManager.CreateAsync(new IdentityRole(rolePadrao));
            }

            var roleResult = await _userManager.AddToRoleAsync(user, rolePadrao);
            if (!roleResult.Succeeded)
            {
                var roleErrors = roleResult.Errors.Select(e => e.Description);
                return BadRequest(new { message = "Usuário criado, mas não foi possível vincular role padrão.", errors = roleErrors });
            }

            return Ok(new { message = "Usuário registrado com sucesso." });
        }

        ///<summary>
        ///Faz login do usuário.
        ///POST /api/auth/login
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                dto.Email, dto.Password, isPersistent: false, lockoutOnFailure: false);
            // isPersistent: se o cookie de autenticação deve ser persistente (permanecer após fechar o navegador)     
            //lockoutOnFailure: se deve bloquear a conta após falhas consecutivas de login
            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Email ou senha inválidos. " });
            }

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return Unauthorized(new { message = "Usuário não encontrado após login." });

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(new UserDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email ?? string.Empty,
                UserName = user.UserName ?? string.Empty,
                FotoPerfil = user.FotoPerfil,
                Roles = roles,
                Telefone = user.PhoneNumber ?? string.Empty,
                Logradouro = user.Logradouro ?? string.Empty,
                Numero = user.Numero ?? string.Empty,
                Complemento = user.Complemento,
                Bairro = user.Bairro ?? string.Empty,
                Cidade = user.Cidade ?? string.Empty,
                Estado = user.Estado ?? string.Empty,
                Cep = user.Cep ?? string.Empty
            });
        }

        /// <summary>
        /// Faz logout do usuário
        /// POST /api/auth/logout
        /// </summary>
        [HttpPost("logout")]
        [Authorize]  //autorização
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Logout realizado com sucesso!" });
        }


        /// <summary>
        /// Retorna os dados do usuário autenticado
        /// GET /api/auth/me
        /// </summary>
        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserDto>> Me()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Usuário não autenticado."
                });
            }

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(new UserDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email ?? string.Empty,
                UserName = user.UserName ?? string.Empty,
                FotoPerfil = user.FotoPerfil,
                Roles = roles,
                Telefone = user.PhoneNumber ?? string.Empty,
                Logradouro = user.Logradouro ?? string.Empty,
                Numero = user.Numero ?? string.Empty,
                Complemento = user.Complemento,
                Bairro = user.Bairro ?? string.Empty,
                Cidade = user.Cidade ?? string.Empty,
                Estado = user.Estado ?? string.Empty,
                Cep = user.Cep ?? string.Empty
            });
        }

        // =====================================================================
        // PUT /api/auth/profile
        // Atualiza o próprio perfil do usuário autenticado
        // =====================================================================
        [HttpPut("profile")]
        [Authorize]
        public async Task<ActionResult<UserDto>> UpdateProfile(
            [FromBody] UpdateProfileDto dto)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized(new
                {
                    message = "Usuário não autenticado."
                });

            // ---------------------------------------------------------
            // VALIDAÇÃO DO NOME
            // ---------------------------------------------------------
            if (string.IsNullOrWhiteSpace(dto.Nome))
            {
                return BadRequest(new
                {
                    message = "O nome é obrigatório."
                });
            }

            if (dto.Nome.Trim().Length < 2)
            {
                return BadRequest(new
                {
                    message = "O nome deve possuir pelo menos 2 caracteres."
                });
            }

            // ---------------------------------------------------------
            // E-MAIL
            // ---------------------------------------------------------
            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                return BadRequest(new
                {
                    message = "O e-mail é obrigatório."
                });
            }

            var email = dto.Email.Trim();

            if (!string.Equals(
                user.Email,
                email,
                StringComparison.OrdinalIgnoreCase))
            {
                var outroUsuario =
                    await _userManager.FindByEmailAsync(email);

                if (outroUsuario != null &&
                    outroUsuario.Id != user.Id)
                {
                    return BadRequest(new
                    {
                        message = "Este e-mail já está sendo utilizado por outro usuário."
                    });
                }

                var emailResult =
                    await _userManager.SetEmailAsync(user, email);

                if (!emailResult.Succeeded)
                {
                    return BadRequest(new
                    {
                        message = string.Join(
                            "; ",
                            emailResult.Errors.Select(e => e.Description))
                    });
                }

                var usernameResult =
                    await _userManager.SetUserNameAsync(user, email);

                if (!usernameResult.Succeeded)
                {
                    return BadRequest(new
                    {
                        message = string.Join(
                            "; ",
                            usernameResult.Errors.Select(e => e.Description))
                    });
                }
            }

            // ---------------------------------------------------------
            // DADOS PESSOAIS
            // ---------------------------------------------------------
            user.Nome = dto.Nome.Trim();
            user.PhoneNumber = dto.Telefone?.Trim() ?? string.Empty;

            // ---------------------------------------------------------
            // ENDEREÇO
            // ---------------------------------------------------------
            user.Logradouro = dto.Logradouro?.Trim() ?? string.Empty;
            user.Numero = dto.Numero?.Trim() ?? string.Empty;

            user.Complemento =
                string.IsNullOrWhiteSpace(dto.Complemento)
                    ? null
                    : dto.Complemento.Trim();

            user.Bairro = dto.Bairro?.Trim() ?? string.Empty;
            user.Cidade = dto.Cidade?.Trim() ?? string.Empty;
            user.Estado = dto.Estado?.Trim().ToUpper() ?? string.Empty;
            user.Cep = dto.Cep?.Trim() ?? string.Empty;
            user.FotoPerfil = string.IsNullOrWhiteSpace(dto.FotoPerfil)
            ? user.FotoPerfil
            : dto.FotoPerfil;

            // ---------------------------------------------------------
            // ALTERAÇÃO DE SENHA
            // ---------------------------------------------------------
            bool desejaAlterarSenha =
                !string.IsNullOrWhiteSpace(dto.CurrentPassword) ||
                !string.IsNullOrWhiteSpace(dto.NewPassword) ||
                !string.IsNullOrWhiteSpace(dto.ConfirmPassword);

            if (desejaAlterarSenha)
            {
                if (string.IsNullOrWhiteSpace(dto.CurrentPassword))
                {
                    return BadRequest(new
                    {
                        message = "Informe sua senha atual."
                    });
                }

                if (string.IsNullOrWhiteSpace(dto.NewPassword))
                {
                    return BadRequest(new
                    {
                        message = "Informe a nova senha."
                    });
                }

                if (dto.NewPassword != dto.ConfirmPassword)
                {
                    return BadRequest(new
                    {
                        message = "A nova senha e a confirmação não coincidem."
                    });
                }

                if (dto.NewPassword.Length < 6)
                {
                    return BadRequest(new
                    {
                        message = "A nova senha deve possuir pelo menos 6 caracteres."
                    });
                }

                var senhaCorreta =
                    await _userManager.CheckPasswordAsync(
                        user,
                        dto.CurrentPassword);

                if (!senhaCorreta)
                {
                    return BadRequest(new
                    {
                        message = "A senha atual está incorreta."
                    });
                }

                var passwordResult =
                    await _userManager.ChangePasswordAsync(
                        user,
                        dto.CurrentPassword,
                        dto.NewPassword);

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

            // ---------------------------------------------------------
            // SALVA OS DADOS DO USUÁRIO
            // ---------------------------------------------------------
            var updateResult =
                await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                return BadRequest(new
                {
                    message = string.Join(
                        "; ",
                        updateResult.Errors.Select(e => e.Description))
                });
            }

            // ---------------------------------------------------------
            // RETORNA USUÁRIO ATUALIZADO
            // ---------------------------------------------------------
            var roles =
                await _userManager.GetRolesAsync(user);

                return Ok(new UserDto
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    Email = user.Email ?? string.Empty,
                    UserName = user.UserName ?? string.Empty,
                    FotoPerfil = user.FotoPerfil,
                    Roles = roles,
                    Telefone = user.PhoneNumber ?? string.Empty,
                    Logradouro = user.Logradouro ?? string.Empty,
                    Numero = user.Numero ?? string.Empty,
                    Complemento = user.Complemento,
                    Bairro = user.Bairro ?? string.Empty,
                    Cidade = user.Cidade ?? string.Empty,
                    Estado = user.Estado ?? string.Empty,
                    Cep = user.Cep ?? string.Empty
                });
        }




    }
}
