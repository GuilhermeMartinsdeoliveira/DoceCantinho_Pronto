using DoceCantinho.Application.DTOs;
using DoceCantinho.Application.Interfaces;
using DoceCantinho.Domain.Entities;
using DoceCantinho.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoceCantinho.Application.Services
{
    /// <summary>
    /// Implementação do serviço de Pedidos.
    /// Orquestra as operações de pedidos entre Controllers e Repository.
    /// </summary>
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<PedidoDto>> GetAllAsync()
        {
            var pedidos = await _pedidoRepository.GetAllAsync();
            return pedidos.Select(MapToDto);
        }

        public async Task<IEnumerable<PedidoDto>> GetByUserIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return Enumerable.Empty<PedidoDto>();

            var pedidos = await _pedidoRepository.GetByUserIdAsync(userId);
            return pedidos.Select(MapToDto);
        }

        public async Task<PedidoDto?> GetByIdAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            return pedido == null ? null : MapToDto(pedido);
        }

        public async Task<PedidoDto> CreateAsync(CreatePedidoDto dto, string userId)
        {
            // Validação básica
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("UserId é obrigatório.", nameof(userId));

            if (string.IsNullOrWhiteSpace(dto.NomeCliente))
                throw new ArgumentException("Nome do cliente é obrigatório.", nameof(dto.NomeCliente));

            if (dto.Total <= 0)
                throw new ArgumentException("Total do pedido deve ser maior que zero.", nameof(dto.Total));

            if (dto.Items == null || !dto.Items.Any())
                throw new ArgumentException("Pedido deve conter pelo menos um item.", nameof(dto.Items));

            var pedido = new Pedido
            {
                UserId = userId,
                NomeCliente = dto.NomeCliente,
                Telefone = dto.Telefone,
                Endereco = dto.Endereco,
                Total = dto.Total,
                PaymentMethod = dto.PaymentMethod,
                Status = "Pendente",
                CreatedAt = DateTime.UtcNow,
                Items = dto.Items.Select(i => new PedidoItem
                {
                    DoceId = i.DoceId,
                    Nome = i.Nome,
                    Preco = i.Preco,
                    Quantidade = i.Quantidade
                }).ToList()
            };

            await _pedidoRepository.AddAsync(pedido);
            return MapToDto(pedido);
        }

        public async Task<PedidoDto?> UpdateAsync(int id, UpdatePedidoDto dto)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
                return null;

            // Apenas Admin pode atualizar dados do pedido (não é o próprio usuário editando)
            pedido.NomeCliente = dto.NomeCliente;
            pedido.Telefone = dto.Telefone;
            pedido.Endereco = dto.Endereco;
            pedido.Total = dto.Total;
            pedido.PaymentMethod = dto.PaymentMethod;
            pedido.Status = dto.Status;

            // Atualizar items
            if (dto.Items != null)
            {
                pedido.Items = dto.Items.Select(i => new PedidoItem
                {
                    DoceId = i.DoceId,
                    Nome = i.Nome,
                    Preco = i.Preco,
                    Quantidade = i.Quantidade
                }).ToList();
            }

            await _pedidoRepository.UpdateAsync(pedido);
            return MapToDto(pedido);
        }

        public async Task<PedidoDto?> UpdateStatusAsync(int id, string newStatus)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
                return null;

            // Validar status
            var statusValidos = new[]
            {
                "Pendente",
                "Pago",
                "Em Preparo",
                "Saiu para Entrega",
                "Entregue",
                "Cancelado"
            };
            if (!statusValidos.Contains(newStatus))
                throw new ArgumentException($"Status '{newStatus}' inválido. Use: {string.Join(", ", statusValidos)}", nameof(newStatus));

            pedido.Status = newStatus;
            await _pedidoRepository.UpdateAsync(pedido);
            return MapToDto(pedido);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
                return false;

            await _pedidoRepository.DeleteAsync(id);
            return true;
        }

        public async Task<int> CountAsync()
        {
            return await _pedidoRepository.CountAsync();
        }

        public async Task<int> CountByUserIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return 0;

            return await _pedidoRepository.CountByUserIdAsync(userId);
        }

        private static PedidoDto MapToDto(Pedido pedido)
        {
            return new PedidoDto
            {
                Id = pedido.Id,
                CreatedAt = pedido.CreatedAt,
                UserId = pedido.UserId,
                NomeCliente = pedido.NomeCliente,
                Telefone = pedido.Telefone,
                Endereco = pedido.Endereco,
                Total = pedido.Total,
                PaymentMethod = pedido.PaymentMethod,
                Status = pedido.Status,
                Items = pedido.Items?.Select(i => new PedidoItemDto
                {
                    Id = i.Id,
                    PedidoId = i.PedidoId,
                    DoceId = i.DoceId,
                    Nome = i.Nome,
                    Preco = i.Preco,
                    Quantidade = i.Quantidade
                }).ToList() ?? new()
            };
        }
    }
}
