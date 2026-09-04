using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DoceCantinho.UI.ViewComponents
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private const string CARRINHO_SESSION_KEY = "Carrinho";

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var session = HttpContext?.Session;
            int quantidade = 0;

            if (session != null)
            {
                var json = session.GetString(CARRINHO_SESSION_KEY);
                if (!string.IsNullOrEmpty(json))
                {
                    try
                    {
                        using var doc = JsonDocument.Parse(json);
                        if (doc.RootElement.TryGetProperty("Itens", out var itens))
                        {
                            foreach (var it in itens.EnumerateArray())
                            {
                                if (it.TryGetProperty("Quantidade", out var q))
                                {
                                    if (q.TryGetInt32(out var v)) quantidade += v;
                                }
                            }
                        }
                    }
                    catch
                    {
                        // ignore parse errors
                    }
                }
            }

            return View(quantidade);
        }
    }
}
