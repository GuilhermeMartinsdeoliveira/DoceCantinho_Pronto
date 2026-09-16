using DoceCantinho.Application.DTOs;
using DoceCantinho.Infrastructure.Identity;
using DoceCantinho.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoceCantinho.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EmailService _emailService;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            EmailService emailService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _configuration = configuration;
        }

        // =====================================================
        // LOGIN
        // =====================================================

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(
            LoginDto dto,
            string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var result = await _signInManager.PasswordSignInAsync(
                dto.Email,
                dto.Password,
                isPersistent: false,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user =
                    await _userManager.FindByEmailAsync(dto.Email);

                // -------------------------------------------------
                // ReturnUrl
                // -------------------------------------------------

                if (!string.IsNullOrEmpty(returnUrl) &&
                    Url.IsLocalUrl(returnUrl))
                {
                    var isAdminArea =
                        returnUrl.StartsWith(
                            "/Admin",
                            StringComparison.OrdinalIgnoreCase);

                    if (isAdminArea)
                    {
                        if (user != null)
                        {
                            var roles =
                                await _userManager.GetRolesAsync(user);

                            if (roles.Contains("Admin"))
                            {
                                return Redirect(returnUrl);
                            }
                        }

                        return RedirectToAction(
                            "Index",
                            "Home");
                    }

                    return Redirect(returnUrl);
                }

                // -------------------------------------------------
                // Admin
                // -------------------------------------------------

                if (user != null)
                {
                    var roles =
                        await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction(
                            "Index",
                            "Admin");
                    }
                }

                // -------------------------------------------------
                // Usuário comum
                // -------------------------------------------------

                return RedirectToAction(
                    "Index",
                    "Home");
            }

            ModelState.AddModelError(
                string.Empty,
                "Email ou senha inválidos.");

            return View(dto);
        }

        // =====================================================
        // LOGIN / CADASTRO COM GOOGLE
        // =====================================================

        [HttpGet]
        public IActionResult ExternalLogin(
            string provider,
            string? returnUrl = null)
        {
            if (string.IsNullOrWhiteSpace(provider))
            {
                return RedirectToAction(nameof(Login));
            }

            var redirectUrl = Url.Action(
                nameof(ExternalLoginCallback),
                "Account",
                new
                {
                    returnUrl
                });

            var properties =
                _signInManager.ConfigureExternalAuthenticationProperties(
                    provider,
                    redirectUrl!);

            return Challenge(
                properties,
                provider);
        }

        // =====================================================
        // CALLBACK DO GOOGLE
        // =====================================================

        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(
            string? returnUrl = null,
            string? remoteError = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            // -------------------------------------------------
            // Erro retornado pelo Google
            // -------------------------------------------------

            if (!string.IsNullOrWhiteSpace(remoteError))
            {
                ModelState.AddModelError(
                    string.Empty,
                    $"Erro ao entrar com Google: {remoteError}");

                return View("Login");
            }

            // -------------------------------------------------
            // Recupera informações do Google
            // -------------------------------------------------

            var info =
                await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Não foi possível obter as informações da conta Google.");

                return View("Login");
            }

            // -------------------------------------------------
            // Verifica se o Google já está vinculado
            // -------------------------------------------------

            var loginResult =
                await _signInManager.ExternalLoginSignInAsync(
                    info.LoginProvider,
                    info.ProviderKey,
                    isPersistent: false,
                    bypassTwoFactor: true);

            if (loginResult.Succeeded)
            {
                var existingUser =
                    await _userManager.FindByLoginAsync(
                        info.LoginProvider,
                        info.ProviderKey);

                return await RedirecionarDepoisDoLoginAsync(
                    existingUser,
                    returnUrl);
            }

            // -------------------------------------------------
            // Recupera e-mail
            // -------------------------------------------------

            var email =
                info.Principal.FindFirstValue(
                    ClaimTypes.Email);

            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError(
                    string.Empty,
                    "O Google não forneceu um e-mail válido.");

                return View("Login");
            }

            // -------------------------------------------------
            // Verifica se já existe usuário pelo e-mail
            // -------------------------------------------------

            var user =
                await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                // -------------------------------------------------
                // Conta já existe.
                // Vincula Google à conta existente.
                // -------------------------------------------------

                var existingLogins =
                    await _userManager.GetLoginsAsync(user);

                var alreadyLinked =
                    existingLogins.Any(x =>
                        x.LoginProvider == info.LoginProvider &&
                        x.ProviderKey == info.ProviderKey);

                if (!alreadyLinked)
                {
                    var addLoginResult =
                        await _userManager.AddLoginAsync(
                            user,
                            info);

                    if (!addLoginResult.Succeeded)
                    {
                        foreach (var error in addLoginResult.Errors)
                        {
                            ModelState.AddModelError(
                                string.Empty,
                                error.Description);
                        }

                        return View("Login");
                    }
                }

                await _signInManager.SignInAsync(
                    user,
                    isPersistent: false);

                return await RedirecionarDepoisDoLoginAsync(
                    user,
                    returnUrl);
            }

            // -------------------------------------------------
            // NOVO USUÁRIO GOOGLE
            // -------------------------------------------------

            var nome =
                info.Principal.FindFirstValue(
                    ClaimTypes.GivenName);

            var sobrenome =
                info.Principal.FindFirstValue(
                    ClaimTypes.Surname);

            if (string.IsNullOrWhiteSpace(nome))
            {
                nome =
                    info.Principal.FindFirstValue(
                        ClaimTypes.Name);
            }

            // -------------------------------------------------
            // Guarda os dados temporariamente
            // -------------------------------------------------

            TempData["GoogleLoginProvider"] =
                info.LoginProvider;

            TempData["GoogleProviderKey"] =
                info.ProviderKey;

            TempData["GoogleEmail"] =
                email;

            TempData["GoogleNome"] =
                nome ?? string.Empty;

            TempData["GoogleSobrenome"] =
                sobrenome ?? string.Empty;

            TempData["GoogleReturnUrl"] =
                returnUrl ?? string.Empty;

            // -------------------------------------------------
            // Vai para cadastro complementar
            // -------------------------------------------------

            return RedirectToAction(
                nameof(Register),
                new
                {
                    returnUrl,
                    google = true
                });
        }

        // =====================================================
        // REGISTER - GET
        // =====================================================

        [HttpGet]
        public IActionResult Register(
            string? returnUrl = null,
            bool google = false)
        {
            ViewData["ReturnUrl"] = returnUrl;

            // -------------------------------------------------
            // Cadastro vindo do Google
            // -------------------------------------------------

            if (google &&
                TempData["GoogleEmail"] != null)
            {
                var dto = new RegisterDto
                {
                    Email =
                        TempData["GoogleEmail"]?.ToString()
                        ?? string.Empty,

                    Nome =
                        TempData["GoogleNome"]?.ToString()
                        ?? string.Empty,

                    Sobrenome =
                        TempData["GoogleSobrenome"]?.ToString()
                        ?? string.Empty
                };

                // Coloca novamente no TempData para o POST.
                TempData.Keep("GoogleLoginProvider");
                TempData.Keep("GoogleProviderKey");
                TempData.Keep("GoogleEmail");
                TempData.Keep("GoogleNome");
                TempData.Keep("GoogleSobrenome");
                TempData.Keep("GoogleReturnUrl");

                ViewBag.GoogleCadastro = true;

                return View(dto);
            }

            return View();
        }

        // =====================================================
        // REGISTER - POST
        // =====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(
            RegisterDto dto,
            string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            // CPF é armazenado somente com os 11 dígitos.
            dto.Cpf = NormalizarCpf(dto.Cpf);

            if (dto.Cpf.Length != 11)
            {
                ModelState.AddModelError(nameof(dto.Cpf), "Informe um CPF com 11 dígitos.");
            }
            else if (await _userManager.Users.AnyAsync(u => u.Cpf == dto.Cpf))
            {
                ModelState.AddModelError(nameof(dto.Cpf), "Este CPF já está cadastrado em outra conta.");
            }

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            // =================================================
            // VERIFICA SE É CADASTRO GOOGLE
            // =================================================

            var googleProvider =
                TempData["GoogleLoginProvider"]?.ToString();

            var googleProviderKey =
                TempData["GoogleProviderKey"]?.ToString();

            var googleEmail =
                TempData["GoogleEmail"]?.ToString();

            var isGoogleRegistration =
                !string.IsNullOrWhiteSpace(googleProvider) &&
                !string.IsNullOrWhiteSpace(googleProviderKey) &&
                !string.IsNullOrWhiteSpace(googleEmail);

            // =================================================
            // CADASTRO GOOGLE
            // =================================================

            if (isGoogleRegistration)
            {
                // ---------------------------------------------
                // O e-mail deve ser o fornecido pelo Google.
                // ---------------------------------------------

                dto.Email = googleEmail!;

                // ---------------------------------------------
                // Procura novamente para evitar duplicação.
                // ---------------------------------------------

                var existingUser =
                    await _userManager.FindByEmailAsync(
                        googleEmail!);

                if (existingUser != null)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "Já existe uma conta com esse e-mail.");

                    return View(dto);
                }

                // ---------------------------------------------
                // Cria usuário SEM senha.
                // O acesso será feito pelo Google.
                // ---------------------------------------------

                var user = new ApplicationUser
                {
                    UserName = googleEmail,
                    Email = googleEmail,

                    Nome =
                        string.IsNullOrWhiteSpace(dto.Sobrenome)
                            ? dto.Nome
                            : $"{dto.Nome} {dto.Sobrenome}",

                    Cpf = dto.Cpf,

                    Logradouro = dto.Logradouro,
                    Numero = dto.Numero,
                    Complemento = dto.Complemento,
                    Bairro = dto.Bairro,
                    Cidade = dto.Cidade,
                    Estado = dto.Estado,
                    Cep = dto.Cep
                };

                var createResult =
                    await _userManager.CreateAsync(user);

                if (!createResult.Succeeded)
                {
                    foreach (var error in createResult.Errors)
                    {
                        ModelState.AddModelError(
                            string.Empty,
                            error.Description);
                    }

                    return View(dto);
                }

                // ---------------------------------------------
                // Adiciona papel de usuário comum.
                // ---------------------------------------------

                var roleResult =
                    await _userManager.AddToRoleAsync(
                        user,
                        "Usuário");

                if (!roleResult.Succeeded)
                {
                    foreach (var error in roleResult.Errors)
                    {
                        ModelState.AddModelError(
                            string.Empty,
                            error.Description);
                    }

                    await _userManager.DeleteAsync(user);

                    return View(dto);
                }

                // ---------------------------------------------
                // Recupera informações externas novamente.
                // ---------------------------------------------

                var externalInfo =
                    await _signInManager.GetExternalLoginInfoAsync();

                if (externalInfo == null)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "Não foi possível vincular sua conta Google.");

                    await _userManager.DeleteAsync(user);

                    return View(dto);
                }

                // ---------------------------------------------
                // Vincula Google ao usuário.
                // ---------------------------------------------

                var addLoginResult =
                    await _userManager.AddLoginAsync(
                        user,
                        externalInfo);

                if (!addLoginResult.Succeeded)
                {
                    foreach (var error in addLoginResult.Errors)
                    {
                        ModelState.AddModelError(
                            string.Empty,
                            error.Description);
                    }

                    await _userManager.DeleteAsync(user);

                    return View(dto);
                }

                // ---------------------------------------------
                // Login automático
                // ---------------------------------------------

                await _signInManager.SignInAsync(
                    user,
                    isPersistent: false);

                // ---------------------------------------------
                // Redirecionamento
                // ---------------------------------------------

                var googleReturnUrl =
                    TempData["GoogleReturnUrl"]?.ToString();

                if (!string.IsNullOrWhiteSpace(returnUrl) &&
                    Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                if (!string.IsNullOrWhiteSpace(googleReturnUrl) &&
                    Url.IsLocalUrl(googleReturnUrl))
                {
                    return Redirect(googleReturnUrl);
                }

                return RedirectToAction(
                    "Index",
                    "Home");
            }

            // =================================================
            // CADASTRO NORMAL
            // =================================================

            if (dto.Password != dto.ConfirmPassword)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "As senhas não coincidem.");

                return View(dto);
            }

            var normalUser = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,

                Nome =
                    string.IsNullOrWhiteSpace(dto.Sobrenome)
                        ? dto.Nome
                        : $"{dto.Nome} {dto.Sobrenome}",

                Cpf = dto.Cpf,

                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Estado = dto.Estado,
                Cep = dto.Cep
            };

            var result =
                await _userManager.CreateAsync(
                    normalUser,
                    dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(
                    normalUser,
                    "Usuário");

                await _signInManager.SignInAsync(
                    normalUser,
                    isPersistent: false);

                // ---------------------------------------------
                // ReturnUrl
                // ---------------------------------------------

                if (!string.IsNullOrEmpty(returnUrl) &&
                    Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction(
                    "Index",
                    "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    error.Description);
            }

            return View(dto);
        }

        // =====================================================
        // ESQUECI MINHA SENHA
        // =====================================================

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(
            string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ViewBag.Erro = "Informe seu e-mail.";

                return View();
            }

            var user =
                await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                ViewBag.Mensagem =
                    "Se existir uma conta com esse e-mail, enviaremos um link para redefinição da senha.";

                return View();
            }

            var token =
                await _userManager.GeneratePasswordResetTokenAsync(
                    user);

            var appUrl =
                _configuration["AppUrl"]?.TrimEnd('/');

            if (string.IsNullOrWhiteSpace(appUrl))
            {
                ViewBag.Erro =
                    "O endereço da aplicação não foi configurado.";

                return View();
            }

            var resetLink =
                $"{appUrl}/Account/ResetPassword" +
                $"?email={Uri.EscapeDataString(user.Email!)}" +
                $"&token={Uri.EscapeDataString(token)}";

            await _emailService.EnviarRecuperacaoSenhaAsync(
                user.Email!,
                resetLink);

            ViewBag.Mensagem =
                "Se existir uma conta com esse e-mail, enviaremos um link para redefinição da senha.";

            return View();
        }

        // =====================================================
        // REDEFINIR SENHA - GET
        // =====================================================

        [HttpGet]
        public IActionResult ResetPassword(
            string? email,
            string? token)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction(nameof(Login));
            }

            var model = new ResetPasswordDto
            {
                Email = email,
                Token = token
            };

            return View(model);
        }

        // =====================================================
        // REDEFINIR SENHA - POST
        // =====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(
            ResetPasswordDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var user =
                await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Não foi possível redefinir a senha.");

                return View(dto);
            }

            var result =
                await _userManager.ResetPasswordAsync(
                    user,
                    dto.Token,
                    dto.Password);

            if (result.Succeeded)
            {
                TempData["Mensagem"] =
                    "Sua senha foi alterada com sucesso. Agora você pode entrar.";

                return RedirectToAction(nameof(Login));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    error.Description);
            }

            return View(dto);
        }

        // =====================================================
        // LOGOUT
        // =====================================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(
                "Index",
                "Home");
        }

        // =====================================================
        // ACCESS DENIED
        // =====================================================

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        // =====================================================
        // REDIRECIONAMENTO APÓS LOGIN
        // =====================================================

        private async Task<IActionResult> RedirecionarDepoisDoLoginAsync(
            ApplicationUser? user,
            string? returnUrl)
        {
            // -------------------------------------------------
            // ReturnUrl seguro
            // -------------------------------------------------

            if (!string.IsNullOrWhiteSpace(returnUrl) &&
                Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            // -------------------------------------------------
            // Verifica Admin
            // -------------------------------------------------

            if (user != null)
            {
                var roles =
                    await _userManager.GetRolesAsync(user);

                if (roles.Contains("Admin"))
                {
                    return RedirectToAction(
                        "Index",
                        "Admin");
                }
            }

            // -------------------------------------------------
            // Usuário comum
            // -------------------------------------------------

            return RedirectToAction(
                "Index",
                "Home");
        }
        private static string NormalizarCpf(string? cpf)
        {
            return new string((cpf ?? string.Empty).Where(char.IsDigit).ToArray());
        }

    }
}