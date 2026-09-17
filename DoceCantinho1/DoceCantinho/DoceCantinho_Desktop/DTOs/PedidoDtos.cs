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
    }

    public class PedidoDetalheDto : PedidoResponseDto
    {
        public string? Endereco { get; set; }
        public List<PedidoItemDto> Items { get; set; } = new List<PedidoItemDto>();
    }

    public class PedidoItemDto
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class BatchStatusDto
    {
        public List<int> Ids { get; set; } = new List<int>();
        public string Status { get; set; } = string.Empty;
    }
}
