using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using DoceCantinho.Application.ViewModels;
using DoceCantinho.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;


namespace DoceCantinho.UI.Controllers
{
    // [Authorize(Roles = "Admin")] - Comentado para permitir acesso durante testes
    public class AdminController : Controller
    {
        private readonly IDoceService _doceService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DoceCantinho.Infrastructure.Context.DoceCantinhoDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IDoceService doceService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment, DoceCantinho.Infrastructure.Context.DoceCantinhoDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _doceService = doceService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // =====================
        // CRUD de Usuários (Admin)
        // =====================

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).Where(n => n != null).ToListAsync();
            var vm = new DoceCantinho.UI.ViewModels.CreateUserViewModel { Roles = roles! };
            ViewData["ActiveMenu"] = "Usuarios";
            ViewData["Title"] = "Novo Usuario";
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(DoceCantinho.UI.ViewModels.CreateUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            if (string.IsNullOrWhiteSpace(model.Password) || model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("Password", "As senhas não coincidem.");
                return View(model);
            }

            var existing = await _userManager.FindByEmailAsync(model.Email);
            if (existing != null)
            {
                ModelState.AddModelError("Email", "Já existe um usuário com este e-mail.");
                return View(model);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, EmailConfirmed = true, Cpf = "000.000.000-00", Logradouro = string.Empty, Bairro = string.Empty, Cidade = string.Empty, Estado = string.Empty, Numero = string.Empty, Cep = string.Empty };
            var res = await _userManager.CreateAsync(user, model.Password);
            if (!res.Succeeded)
            {
                foreach (var e in res.Errors) ModelState.AddModelError(string.Empty, e.Description);
                return View(model);
            }

            var role = string.IsNullOrWhiteSpace(model.Role) ? "Usuário" : model.Role;
            if (!await _roleManager.RoleExistsAsync(role)) await _roleManager.CreateAsync(new IdentityRole(role));
            await _userManager.AddToRoleAsync(user, role);

            TempData["Success"] = "Usuário criado com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var roles = await _roleManager.Roles.Select(r => r.Name).Where(n => n != null).ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);

            var vm = new DoceCantinho.UI.ViewModels.EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email ?? string.Empty,
                Role = userRoles.FirstOrDefault() ?? "Usuário",
                Roles = roles!
            };
            ViewData["ActiveMenu"] = "Usuarios";
            ViewData["Title"] = "Editar Usuario";
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(DoceCantinho.UI.ViewModels.EditUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null) return NotFound();

            user.Email = model.Email;
            user.UserName = model.Email;
            var updateRes = await _userManager.UpdateAsync(user);
            if (!updateRes.Succeeded)
            {
                foreach (var e in updateRes.Errors) ModelState.AddModelError(string.Empty, e.Description);
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetRes = await _userManager.ResetPasswordAsync(user, token, model.Password);
                if (!resetRes.Succeeded)
                {
                    foreach (var e in resetRes.Errors) ModelState.AddModelError(string.Empty, e.Description);
                    return View(model);
                }
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!string.IsNullOrWhiteSpace(model.Role))
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!await _roleManager.RoleExistsAsync(model.Role)) await _roleManager.CreateAsync(new IdentityRole(model.Role));
                await _userManager.AddToRoleAsync(user, model.Role);
            }

            TempData["Success"] = "Usuário atualizado com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            ViewData["ActiveMenu"] = "Usuarios";
            ViewData["Title"] = "Excluir Usuario";
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var res = await _userManager.DeleteAsync(user);
            if (!res.Succeeded)
            {
                TempData["Error"] = "Não foi possível excluir o usuário.";
                return RedirectToAction(nameof(Index));
            }
            TempData["Success"] = "Usuário excluído.";
            return RedirectToAction(nameof(Index));
        }

        // ==========================================
        // UPLOAD DE IMAGEM
        // ==========================================
        // Salva o arquivo de imagem enviado dentro de wwwroot/uploads/doces
        // e retorna a URL relativa (ex: "/uploads/doces/guid.jpg") que fica
        // gravada no campo CoverImageUrl.
        private async Task<string?> SalvarImagemAsync(IFormFile? imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            var extensoesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            var extensao = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

            if (!extensoesPermitidas.Contains(extensao))
                throw new ArgumentException("Formato de imagem inválido. Use JPG, PNG, GIF ou WEBP.");

            var pastaUploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "doces");
            Directory.CreateDirectory(pastaUploads);

            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";
            var caminhoCompleto = Path.Combine(pastaUploads, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"/uploads/doces/{nomeArquivo}";
        }

        // ==========================================
        // DASHBOARD ADMINISTRATIVO
        // ==========================================
        public async Task<IActionResult> Index()
        {
            ViewData["ActiveMenu"] = "Dashboard";
            ViewData["Title"] = "Dashboard";
            ViewData["Subtitle"] = "Resumo do sistema DoceCantinho";

            var viewModel = new DashboardViewModel
            {
                TotalDoces = await _doceService.CountAsync(),
                TotalCategories = await _categoryService.CountAsync(),
                FeaturedDoces = (await _doceService.GetFeaturedAsync()).Count(),
                RecentDoces = (await _doceService.GetAllAsync()).Take(5),
                Categories = await _categoryService.GetAllAsync()
            };

            // ==========================================
            // PEDIDOS — dados 100% vindos do banco (sem mocks)
            // ==========================================
            var culturaPtBr = new System.Globalization.CultureInfo("pt-BR");

            // Intervalo do dia atual (a partir do UTC, mesmo padrão usado ao salvar CreatedAt no checkout)
            var inicioHoje = DateTime.UtcNow.Date;
            var inicioAmanha = inicioHoje.AddDays(1);
            var inicioOntem = inicioHoje.AddDays(-1);

            // Todos os pedidos (para a aba "Pedidos" completa) — mais recentes primeiro
            var todosPedidos = await _db.Pedidos
                .Include(p => p.Items)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            // Pedidos realizados hoje (para a seção "Pedidos Recentes" e o KPI "Pedidos Hoje")
            var pedidosDeHoje = todosPedidos
                .Where(p => p.CreatedAt >= inicioHoje && p.CreatedAt < inicioAmanha)
                .ToList();

            // Pedidos de ontem, usado apenas para mostrar uma variação real (não fictícia) no KPI
            var pedidosDeOntemCount = todosPedidos
                .Count(p => p.CreatedAt >= inicioOntem && p.CreatedAt < inicioHoje);

            // Todos os pedidos (histórico completo) e os pedidos de hoje, prontos para o Razor renderizar
            // diretamente na view — sem serialização JSON/JS, 100% server-side.
            ViewData["PedidosAdmin"] = todosPedidos;
            ViewData["PedidosHojeAdmin"] = pedidosDeHoje.Take(5).ToList();

            // KPI "Pedidos Hoje" calculado diretamente do banco
            ViewData["PedidosHojeCount"] = pedidosDeHoje.Count;
            var variacaoPedidosHoje = pedidosDeHoje.Count - pedidosDeOntemCount;
            ViewData["PedidosHojeVariacao"] = variacaoPedidosHoje;

            // KPI: Receita Mensal (soma dos pedidos deste mês)
            var inicioMes = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            var inicioProximoMes = inicioMes.AddMonths(1);
            var receitaMensal = await _db.Pedidos
                .Where(p => p.CreatedAt >= inicioMes && p.CreatedAt < inicioProximoMes)
                .SumAsync(p => (decimal?)p.Total) ?? 0m;
            ViewData["MonthlyRevenue"] = receitaMensal.ToString("C2", culturaPtBr);

            // KPI: Produtos Ativos (usa TotalDoces do viewModel)
            ViewData["ProdutosAtivos"] = viewModel.TotalDoces;

            // Caso UsersJson tenha sido criado acima, ViewData["UsersTotal"] já existe.
            ViewData["ClientsCount"] = ViewData["UsersTotal"] ?? 0;

            // ====== Usuários (para a aba Clientes) ======
            try
            {
                var users = await _db.Users
                    .Select(u => new {
                        Id = u.Id,
                        Email = u.Email,
                        EmailConfirmed = u.EmailConfirmed
                    })
                    .ToListAsync();

                // Carregar roles via tabelas de relacionamento do Identity
                var userRoles = await _db.UserRoles.ToListAsync();
                var roles = await _db.Roles.ToListAsync();

                var usersDto = users.Select(u => new {
                    id = u.Id,
                    email = u.Email ?? string.Empty,
                    roles = userRoles
                                .Where(ur => ur.UserId == u.Id)
                                .Join(roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name)
                                .Where(n => !string.IsNullOrEmpty(n))
                                .ToList(),
                    emailConfirmed = u.EmailConfirmed
                }).ToList();

                ViewData["UsersJson"] = System.Text.Json.JsonSerializer.Serialize(usersDto);
                ViewData["UsersTotal"] = usersDto.Count;
                ViewData["UsersActive"] = usersDto.Count(u => (u.roles != null && u.roles.Count > 0) || (bool)u.emailConfirmed);
                // Compatibilidade com nomes em português usados nas views
                ViewData["ClientesAtivos"] = ViewData["UsersActive"];
                ViewData["AdminsCount"] = usersDto.Count(u => u.roles != null && u.roles.Contains("Admin"));
            }
            catch
            {
                // Ignore erros aqui — a view tratará quando ViewData["UsersJson"] estiver ausente
            }

            return View(viewModel);
        }

        // ==========================================
        // CRUD DE DOCE
        // ==========================================

        public async Task<IActionResult> Doces()
        {
            ViewData["ActiveMenu"] = "Doces";
            ViewData["Title"] = "Gerenciar Doces";
            ViewData["Subtitle"] = "Cadastre, edite e exclua doces do catálogo";

            var doces = await _doceService.GetAllAsync();
            return View(doces);
        }

        /// <summary>
        /// Formulário para criação de um novo game.
        /// GET : /Admin/CreateGame
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CreateDoce()
        {
            ViewData["ActiveMenu"] = "Doces";
            ViewData["Title"] = "Cadastrar Novo Doce";

            var categories = await _categoryService.GetAllAsync();
            var viewModel = new DoceFormViewModel
            {
                Categories = categories
            };

            return View(viewModel);
        }

        //Processa a criação de um novo game.
        // POST : /Admin/CreateGame
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDoce(DoceFormViewModel viewModel, IFormFile? imageFile)
        {
            // Se um arquivo de imagem foi enviado, ele tem prioridade sobre a URL digitada.
            var imagemFileUrl = await SalvarImagemAsync(imageFile);

            var dto = new CreateDoceDto
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                CoverImageUrl = imagemFileUrl ?? viewModel.CoverImageUrl,
                CategoryId = viewModel.CategoryId,
                Preco = viewModel.Preco,
                IsFeatured = viewModel.IsFeatured,
                IsRecomendado = viewModel.IsRecomendado
            };

            await _doceService.CreateAsync(dto);
            TempData["Success"] = "Doce cadastrado com sucesso!";
            return RedirectToAction(nameof(Doces));
        }

        [HttpGet]
        public async Task<IActionResult> EditDoces(int id)
        {
            ViewData["ActiveMenu"] = "Doces";
            ViewData["Title"] = "Editar Doce";

            var doce = await _doceService.GetByIdAsync(id);
            if (doce == null) return NotFound();

            var categories = await _categoryService.GetAllAsync();
            var viewModel = new DoceFormViewModel
            {
                Id = doce.Id,
                Title = doce.Title,
                Description = doce.Description,
                CoverImageUrl = doce.CoverImageUrl,
                CategoryId = doce.CategoryId,
                IsFeatured = doce.IsFeatured,
                IsRecomendado = doce.IsRecomendado,
                Preco = doce.Preco,
                Categories = categories
            };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDoces(int id, DoceFormViewModel viewModel, IFormFile? imageFile)
        {
            // Se um novo arquivo de imagem foi enviado, ele substitui a imagem/URL atual.
            var imagemFileUrl = await SalvarImagemAsync(imageFile);

            var dto = new UpdateDoceDto
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                CoverImageUrl = imagemFileUrl ?? viewModel.CoverImageUrl,
                CategoryId = viewModel.CategoryId,
                Preco = viewModel.Preco,
                IsFeatured = viewModel.IsFeatured,
                IsRecomendado = viewModel.IsRecomendado
            };

            var result = await _doceService.UpdateAsync(id, dto);

            if (result == null)
                return NotFound();

            TempData["Success"] = "Doce atualizado com sucesso!";
            return RedirectToAction(nameof(Doces));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteDoce(int id)
        {
            ViewData["ActiveMenu"] = "Doces";
            ViewData["Title"] = "Excluir Doce";

            var doce = await _doceService.GetByIdAsync(id);
            if (doce == null) return NotFound();

            return View(doce);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDoceConfirmed(int id)
        {
            await _doceService.DeleteAsync(id);
            TempData["Success"] = "Doce excluído com sucesso!";
            return RedirectToAction(nameof(Doces));
        }

        //==========================================
        // CRUD DE CATEGORIAS
        //==========================================

        public async Task<IActionResult> Categories()
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Gerenciar Categorias";
            ViewData["Subtitle"] = "Cadastre, edite e exclua categorias de doces";

            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Nova Categoria";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            await _categoryService.CreateAsync(dto);
            TempData["Success"] = "Categoria cadastrada com sucesso!";
            return RedirectToAction(nameof(Categories));
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Editar Categoria";

            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return View(new CategoryDto { Id = id, Name = dto.Name });

            var result = await _categoryService.UpdateAsync(id, dto);
            if (result == null) return NotFound();

            TempData["Success"] = "Categoria atualizada com sucesso!";
            return RedirectToAction(nameof(Categories));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            ViewData["ActiveMenu"] = "Categories";
            ViewData["Title"] = "Excluir Categoria";

            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoryConfirmed(int id)
        {
            var deleted = await _categoryService.DeleteAsync(id);
            if (!deleted)
            {
                TempData["Error"] = "Não foi possível excluir a categoria. Verifique se há games associados.";
                return RedirectToAction(nameof(Categories));
            }

            TempData["Success"] = "Categoria excluída com sucesso!";
            return RedirectToAction(nameof(Categories));
        }
    }
}
