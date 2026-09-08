namespace DoceCantinho.Domain.Entities;

public class PedidoItem
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public Pedido? Pedido { get; set; }

    public int DoceId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }

    public decimal Subtotal => Preco * Quantidade;
}
