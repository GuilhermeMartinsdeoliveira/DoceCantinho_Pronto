// =============================================================================
// SenacDoces.Desktop - Services/DocesApiService.cs
// =============================================================================
//  CONCEITO: Service de Doces
//
// Realiza todas as operações CRUD de doces via API REST:
//   GET    /api/doces         Listar todos os doces
//   GET    /api/doces/{id}    Buscar doce por ID
//   POST   /api/doces         Criar doce (requer Admin)
//   PUT    /api/doces/{id}    Atualizar doce (requer Admin)
//   DELETE /api/doces/{id}    Excluir doce (requer Admin)
//
// IMPORTANTE: As operações de escrita (POST, PUT, DELETE) requerem
// que o usuário esteja autenticado como Admin.
// A autorização é verificada pela própria API, não pelo Desktop.
// O Desktop não precisa verificar roles para fazer a chamada —
// mas deve controlar a INTERFACE (exibir/ocultar botões) baseado no perfil.
// =============================================================================



using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;

namespace DoceCantinho.Desktop.Services
{
    /// <summary>
    /// Serviço de comunicação com os endpoints de Doces da API.
    /// </summary>
    public class DoceApiService
    {
        private readonly HttpClientHelper _http;

        public DoceApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        /// <summary>
        /// Lista todos os doces via GET /api/doces.
        /// Disponível para qualquer usuário autenticado.
        /// </summary>
        /// <returns>Lista de doces ou lista vazia em caso de erro</returns>
        public async Task<List<DoceResponseDto>> GetAllAsync()
        {
            try
            {
                var doces = await _http.GetAsync<List<DoceResponseDto>>("/api/doce");
                return doces ?? new List<DoceResponseDto>();
            }
            catch
            {
                return new List<DoceResponseDto>();
            }
        }

        /// <summary>
        /// Busca um doce específico por ID via GET /api/doces/{id}.
        /// </summary>
        public async Task<DoceResponseDto?> GetByIdAsync(int id)
        {
            return await _http.GetAsync<DoceResponseDto>($"/api/doce/{id}");
        }

        /// <summary>
        /// Cria um novo doce via POST /api/doces.
        /// Requer perfil Admin (verificado pela API).
        /// </summary>
        /// <param name="dto">Dados do doce a ser criado</param>
        /// <returns>Doce criado ou null em caso de erro</returns>
        public async Task<(bool Success, DoceResponseDto? Doce, string ErrorMessage)>
            CreateAsync(CreateDoceDto dto)
        {
            return await _http.PostAsync<DoceResponseDto>("/api/doce", dto);
        }

        /// <summary>
        /// Atualiza um doce existente via PUT /api/doces/{id}.
        /// Requer perfil Admin (verificado pela API).
        /// </summary>
        public async Task<(bool Success, DoceResponseDto? Doce, string ErrorMessage)> UpdateAsync(int id, UpdateDoceDto dto)
        {
            return await _http.PutAsync<DoceResponseDto>($"/api/doce/{id}", dto);
        }

        /// <summary>
        /// Exclui um doce via DELETE /api/doces/{id}.
        /// Requer perfil Admin (verificado pela API).
        /// </summary>
        public async Task<(bool Success, string ErrorMessage)> DeleteAsync(int id)
        {
            return await _http.DeleteAsync($"/api/doce/{id}");
        }
    }
}
