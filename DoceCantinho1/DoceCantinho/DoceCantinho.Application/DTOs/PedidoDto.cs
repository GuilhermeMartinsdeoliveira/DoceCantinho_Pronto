using System;
using System.Collections.Generic;
using System.Text;

// =============================================================================
// DoceCantinho.Application - DTO PedidoDto
// =============================================================================
// 🔤 CONCEITO IMPORTANTE: DTO (Data Transfer Object)
// Um DTO é um objeto usado para TRANSFERIR dados entre camadas.
// Ele contém apenas os dados necessários, sem lógica de negócio.
//
// Por que usar DTOs ao invés de enviar a Entidade diretamente?
// 1. Segurança: evita expor dados internos do banco
// 2. Flexibilidade: permite enviar apenas os campos necessários
// 3. Desacoplamento: a API não depende da estrutura do banco
// =============================================================================

namespace DoceCantinho.Application.DTOs
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string NomeCliente { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? Endereco { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = "Pendente";
        public List<PedidoItemDto> Items { get; set; } = new();
    }

    public class PedidoItemDto
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int DoceId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal => Preco * Quantidade;
    }

    public class CreatePedidoDto
    {
        public string NomeCliente { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? Endereco { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public List<CreatePedidoItemDto> Items { get; set; } = new();
    }

    public class CreatePedidoItemDto
    {
        public int DoceId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }

    public class UpdatePedidoDto
    {
        public string NomeCliente { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? Endereco { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Status { get; set; } = "Pendente";
        public List<CreatePedidoItemDto> Items { get; set; } = new();
    }

    public class UpdatePedidoStatusDto
    {
        public string Status { get; set; } = string.Empty;
    }
}
