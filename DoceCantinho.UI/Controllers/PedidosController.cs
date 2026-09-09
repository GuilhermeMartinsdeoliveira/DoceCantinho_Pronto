using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using DoceCantinho.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoceCantinho.UI.Controllers
{
    /// <summary>
    /// Controller para gerenciar Pedidos.
    /// Admin: acesso completo (CRUD)
    /// Usuário comum: visualiza apenas seus pedidos e pode cancelar
    /// </summary>
    [Authorize]
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PedidosController(IPedidoService pedidoService, UserManager<ApplicationUser> userManager)
        {
            _pedidoService = pedidoService;
            _userManager = userManager;
        }

        /// <summary>
        /// Lista todos os pedidos (Admin) ou pedidos do usuário logado (Usuário comum)
        /// GET: /Pedidos/Index
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var isAdmin = User.IsInRole("Admin");

            List<PedidoDto> pedidos;
            if (isAdmin)
            {
                // Admin vê todos os pedidos
                pedidos = (await _pedidoService.GetAllAsync()).ToList();
                ViewData["Title"] = "Gerenciar Pedidos";
                ViewData["IsAdmin"] = true;
            }
            else
            {
                // Usuário comum vê apenas seus pedidos
                pedidos = (await _pedidoService.GetByUserIdAsync(user.Id)).ToList();
                ViewData["Title"] = "Meus Pedidos";
                ViewData["IsAdmin"] = false;
            }

            return View(pedidos);
        }

        /// <summary>
        /// Exibe os detalhes de um pedido específico
        /// GET: /Pedidos/Details/5
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var pedido = await _pedidoService.GetByIdAsync(id.Value);
            if (pedido == null)
                return NotFound();

            // Verificar permissão: Admin pode ver qualquer pedido, usuário comum só seus
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var isAdmin = User.IsInRole("Admin");
            if (!isAdmin && pedido.UserId != user.Id)
                return Forbid(); // Acesso negado

            ViewData["Title"] = "Detalhes do Pedido";
            ViewData["IsAdmin"] = isAdmin;
            return View(pedido);
        }


        [HttpGet]
        public IActionResult NovoPedido()
        {
            return RedirectToAction("Index", "Doces");
        }


        /// <summary>
        /// Formulário para criar novo pedido (apenas Admin)
        /// GET: /Pedidos/Create
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Title"] = "Novo Pedido";
            var dto = new CreatePedidoDto();
            return View(dto);
        }

        /// <summary>
        /// Processa a criação de um novo pedido (apenas Admin)
        /// POST: /Pedidos/Create
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreatePedidoDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Novo Pedido";
                return View(dto);
            }

            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                // Admin criando pedido para si mesmo
                var createdPedido = await _pedidoService.CreateAsync(dto, user.Id);
                TempData["Success"] = "Pedido criado com sucesso!";
                return RedirectToAction(nameof(Details), new { id = createdPedido.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao criar pedido: {ex.Message}");
                ViewData["Title"] = "Novo Pedido";
                return View(dto);
            }
        }

        /// <summary>
        /// Formulário para editar um pedido (apenas Admin)
        /// GET: /Pedidos/Edit/5
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var pedido = await _pedidoService.GetByIdAsync(id.Value);
            if (pedido == null)
                return NotFound();

            ViewData["Title"] = "Editar Pedido";
            var editDto = new UpdatePedidoDto
            {
                NomeCliente = pedido.NomeCliente,
                Telefone = pedido.Telefone,
                Endereco = pedido.Endereco,
                Total = pedido.Total,
                PaymentMethod = pedido.PaymentMethod,
                Status = pedido.Status,
                Items = pedido.Items?.Select(i => new CreatePedidoItemDto
                {
                    DoceId = i.DoceId,
                    Nome = i.Nome,
                    Preco = i.Preco,
                    Quantidade = i.Quantidade
                }).ToList() ?? new()
            };

            return View(editDto);
        }

        /// <summary>
        /// Processa a edição de um pedido (apenas Admin)
        /// POST: /Pedidos/Edit/5
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, UpdatePedidoDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Editar Pedido";
                return View(dto);
            }

            try
            {
                var updatedPedido = await _pedidoService.UpdateAsync(id, dto);
                if (updatedPedido == null)
                    return NotFound();

                TempData["Success"] = "Pedido atualizado com sucesso!";
                return RedirectToAction(nameof(Details), new { id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao editar pedido: {ex.Message}");
                ViewData["Title"] = "Editar Pedido";
                return View(dto);
            }
        }

        /// <summary>
        /// Formulário de confirmação para excluir um pedido (apenas Admin)
        /// GET: /Pedidos/Delete/5
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var pedido = await _pedidoService.GetByIdAsync(id.Value);
            if (pedido == null)
                return NotFound();

            ViewData["Title"] = "Excluir Pedido";
            return View(pedido);
        }

        /// <summary>
        /// Processa a exclusão de um pedido (apenas Admin)
        /// POST: /Pedidos/Delete/5
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _pedidoService.DeleteAsync(id);
                if (!success)
                    return NotFound();

                TempData["Success"] = "Pedido excluído com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao excluir pedido: {ex.Message}";
                return RedirectToAction(nameof(Delete), new { id = id });
            }
        }

        /// <summary>
        /// Cancela um pedido (Usuário comum cancela seu próprio, Admin cancela qualquer)
        /// POST: /Pedidos/Cancel/5
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            if (pedido == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            // Verificar permissão
            var isAdmin = User.IsInRole("Admin");
            if (!isAdmin && pedido.UserId != user.Id)
                return Forbid(); // Não pode cancelar pedido de outro usuário

            // Cliente só pode cancelar pedidos em aberto (Pendente). Admin pode cancelar em qualquer status ativo.
            var podeCancelar = isAdmin
                ? pedido.Status != "Cancelado" && pedido.Status != "Entregue"
                : pedido.Status == "Pendente";

            if (!podeCancelar)
            {
                TempData["Error"] = $"Não é possível cancelar um pedido com status '{pedido.Status}'.";
                return RedirectToAction(nameof(Details), new { id = id });
            }

            try
            {
                var updated = await _pedidoService.UpdateStatusAsync(id, "Cancelado");
                if (updated == null)
                    return NotFound();

                TempData["Success"] = "Pedido cancelado com sucesso!";
                return RedirectToAction(nameof(Details), new { id = id });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao cancelar pedido: {ex.Message}";
                return RedirectToAction(nameof(Details), new { id = id });
            }
        }

        /// <summary>
        /// Atualiza o status de um pedido (apenas Admin)
        /// POST: /Pedidos/UpdateStatus/5
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id, string newStatus)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            if (pedido == null)
                return NotFound();

            try
            {
                var updated = await _pedidoService.UpdateStatusAsync(id, newStatus);
                if (updated == null)
                    return NotFound();

                TempData["Success"] = $"Status do pedido alterado para '{newStatus}' com sucesso!";
                return RedirectToAction(nameof(Details), new { id = id });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Erro ao atualizar status: {ex.Message}";
                return RedirectToAction(nameof(Details), new { id = id });
            }
        }
    }
}
