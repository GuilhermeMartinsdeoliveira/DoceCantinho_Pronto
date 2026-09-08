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

        // ============================================================
        // LISTAR PEDIDOS
        // ============================================================

        public async Task<List<PedidoResponseDto>> GetAllAsync()
        {
            try
            {
                var pedidos =
                    await _http.GetAsync<List<PedidoResponseDto>>(
                        "/api/orders");

                return pedidos ?? new List<PedidoResponseDto>();
            }
            catch
            {
                return new List<PedidoResponseDto>();
            }
        }

        // ============================================================
        // BUSCAR PEDIDO POR ID
        // ============================================================

        public async Task<PedidoDetalheDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _http.GetAsync<PedidoDetalheDto>(
                    $"/api/orders/{id}");
            }
            catch
            {
                return null;
            }
        }

        // ============================================================
        // ATUALIZAR PEDIDO
        // ============================================================

        public async Task<(bool Success, string ErrorMessage)> UpdateAsync(
            int id,
            AtualizarPedidoDto dto)
        {
            var result =
                await _http.PutAsync<object>(
                    $"/api/orders/{id}",
                    dto);

            return (
                result.Success,
                result.ErrorMessage
            );
        }

        // ============================================================
        // EXCLUIR PEDIDO
        // ============================================================

        public async Task<(bool Success, string ErrorMessage)> DeleteAsync(
            int id)
        {
            return await _http.DeleteAsync(
                $"/api/orders/{id}");
        }

        // ============================================================
        // ATUALIZAR STATUS EM LOTE
        // ============================================================

        public async Task<(bool Success, string ErrorMessage)>
            UpdateBatchStatusAsync(
                List<int> ids,
                string status)
        {
            var dto = new BatchStatusDto
            {
                Ids = ids,
                Status = status
            };

            var result =
                await _http.PutAsync<object>(
                    "/api/orders/batch-status",
                    dto);

            return (
                result.Success,
                result.ErrorMessage
            );
        }
    }
}