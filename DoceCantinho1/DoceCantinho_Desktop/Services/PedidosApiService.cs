using System.Collections.Generic;
using System.Threading.Tasks;
using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;

namespace DoceCantinho.Desktop.Services
{
    public class PedidosApiService
    {
        private readonly HttpClientHelper _http;

        public PedidosApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        public async Task<List<PedidoResponseDto>> GetAllAsync()
        {
            try
            {
                var pedidos = await _http.GetAsync<List<PedidoResponseDto>>("/api/orders");
                return pedidos ?? new List<PedidoResponseDto>();
            }
            catch
            {
                return new List<PedidoResponseDto>();
            }
        }

        public async Task<PedidoDetalheDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _http.GetAsync<PedidoDetalheDto>($"/api/orders/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<(bool Success, string ErrorMessage)> UpdateBatchStatusAsync(List<int> ids, string status)
        {
            var dto = new BatchStatusDto { Ids = ids, Status = status };
            return await _http.PutAsync<object>("/api/orders/batch-status", dto)
                .ContinueWith(t => (t.Result.Success, t.Result.ErrorMessage));
        }
    }
}
