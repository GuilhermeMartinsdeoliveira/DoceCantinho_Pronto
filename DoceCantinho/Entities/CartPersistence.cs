using System;

namespace DoceCantinho.Domain.Entities
{
    /// <summary>
    /// Entidade simples para persistir o carrinho do usuário como JSON.
    /// </summary>
    public class CartPersistence
    {
        public int Id { get; set; }

        // Id do usuário (Identity) que possui este carrinho
        public string UserId { get; set; } = string.Empty;

        // Conteúdo do carrinho em JSON (mesma estrutura usada na sessão)
        public string CartJson { get; set; } = string.Empty;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
