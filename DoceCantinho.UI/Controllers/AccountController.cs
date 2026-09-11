using DoceCantinho.Application.DTOs;
using DoceCantinho.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoceCantinho.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
    }
}