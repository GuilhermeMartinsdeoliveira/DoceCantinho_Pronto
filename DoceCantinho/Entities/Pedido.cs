namespace DoceCantinho.Domain.Entities;

using System;
using System.Collections.Generic;

public class Pedido
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // FK para IdentityUser (permite relacionar pedido com usuário autenticado)
    public string UserId { get; set; } = string.Empty;

    public string NomeCliente { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string? Endereco { get; set; }

    public decimal Total { get; set; }

    // Ex.: CartaoCredito, CartaoDebito, Pix
    public string PaymentMethod { get; set; } = string.Empty;

    // Cartão usado no pagamento. O número completo nunca é armazenado.
    public int? CartaoId { get; set; }
    public string? CartaoUltimos4 { get; set; }

    // Ex.: Pendente, Pago, Cancelado
    public string Status { get; set; } = "Pendente";

    public List<PedidoItem> Items { get; set; } = new();
}
