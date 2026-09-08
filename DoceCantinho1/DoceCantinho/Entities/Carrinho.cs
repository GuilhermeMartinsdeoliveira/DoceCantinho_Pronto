namespace DoceCantinho.Domain.Entities;

public class Carrinho
{
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}
