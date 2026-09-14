using DoceCantinho.Application.DTOs;
using DoceCantinho.Infrastructure.Identity;
using DoceCantinho.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoceCantinho.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EmailService _emailService;
        public AccountController(
     UserManager<ApplicationUser> userManager,
     SignInManager<ApplicationUser> signInManager,
     EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
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

                // Se veio de uma página específica,
                // volta para ela.
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
                                return Redirect(returnUrl);
                        }

                        return RedirectToAction(
                            "Index",
                            "Home");
                    }

                    return Redirect(returnUrl);
                }

                // Admin vai para o painel
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
        // REGISTER
        // =====================================================

        [HttpGet]
        public IActionResult Register(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(
            RegisterDto dto,
            string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (dto.Password != dto.ConfirmPassword)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "As senhas não coincidem.");

                return View(dto);
            }

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

            var result =
                await _userManager.CreateAsync(
                    user,
                    dto.Password);

            if (result.Succeeded)
            {
                // Usuário comum
                await _userManager.AddToRoleAsync(
                    user,
                    "Usuário");

                // Login automático
                await _signInManager.SignInAsync(
                    user,
                    isPersistent: false);

                // =================================================
                // IMPORTANTE:
                // Se veio do carrinho, volta para o carrinho.
                // =================================================

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


        //=============================================
        // ESQUECI MINHA SENHA
        //=============================================

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ViewBag.Erro = "Informe seu e-mail.";
                return View();
            }

            var user = await _userManager.FindByEmailAsync(email);

            // Por segurança, não informamos se o e-mail existe ou não.
            if (user == null)
            {
                ViewBag.Mensagem =
                    "Se existir uma conta com esse e-mail, enviaremos um link para redefinição da senha.";

                return View();
            }

            var token =
       await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink =
                Url.Action(
                    nameof(ResetPassword),
                    "Account",
                    new
                    {
                        email = user.Email,
                        token = token
                    },
                    Request.Scheme);

            await _emailService.EnviarRecuperacaoSenhaAsync(
                user.Email!,
                resetLink!);

            ViewBag.Mensagem =
                "Se existir uma conta com esse e-mail, enviaremos um link para redefinição da senha.";

            return View();

            // TEMPORÁRIO:
            // Aqui vamos chamar o serviço de e-mail.
            // Não devemos colocar o token diretamente na tela em produção.

            ViewBag.Mensagem =
                "O link de recuperação foi gerado. Agora vamos configurar o envio por e-mail.";

            return View();
        }


        //=============================================
        // REDEFINIR SENHA
        //=============================================

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(
            ResetPasswordDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

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

        //=============================================
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
    }
}