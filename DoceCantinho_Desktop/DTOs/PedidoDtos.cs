using System;
using System.Collections.Generic;

namespace DoceCantinho.Desktop.DTOs
{
    public class PedidoResponseDto
    {
        public int Id { get; set; }

        public string NomeCliente { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public decimal Total { get; set; }

        public string? PaymentMethod { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public int ItemsCount { get; set; }

        // Usado pela coluna Produtos
        public string Produtos
        {
            get
            {
                return ItemsCount == 1
                    ? "1 produto"
                    : $"{ItemsCount} produtos";
            }
        }
    }

    public class PedidoDetalheDto : PedidoResponseDto
    {
        public string? Endereco { get; set; }

        public List<PedidoItemDto> Items { get; set; } = new();
    }

    public class PedidoItemDto
    {
        public int Id { get; set; }

        public int DoceId { get; set; }

        public string Nome { get; set; } = string.Empty;

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public decimal Subtotal { get; set; }
    }

    public class BatchStatusDto
    {
        public List<int> Ids { get; set; } = new();

        public string Status { get; set; } = string.Empty;
    }

    // ============================================================
    // ATUALIZAR PEDIDO
    // ============================================================

    public class AtualizarPedidoDto
    {
        public string NomeCliente { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string? Endereco { get; set; }

        public List<AtualizarPedidoItemDto> Items { get; set; } = new();
    }

    public class AtualizarPedidoItemDto
    {
        public int DoceId { get; set; }

        public string Nome { get; set; } = string.Empty;

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }
    }
}