// =============================================================================
// SenacDoces.Desktop - Services/UsuariosApiService.cs
// =============================================================================

using DoceCantinho.Desktop.Helpers;
using DoceCantinho.Desktop.DTOs;
using System.Windows.Forms;

namespace DoceCantinho.Desktop.Services
{
    public class UsuariosApiService
    {
        private readonly HttpClientHelper _http;

        public UsuariosApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        public async Task<List<UsuarioResponseDto>> GetAllAsync()
        {
            try
            {
                var usuarios = await _http.GetAsync<List<UsuarioResponseDto>>("/api/usuarios");
                return usuarios ?? new List<UsuarioResponseDto>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[UsuariosApiService] Erro GetAllAsync: {ex.Message}");
                // Exibe MessageBox somente em ambiente de desenvolvimento (Debugger anexado)
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show($"Erro ao obter usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Retorna lista vazia para não quebrar a UI
                return new List<UsuarioResponseDto>();
            }
        }

        public async Task<(bool Success, UsuarioResponseDto? Usuario, string ErrorMessage)> CreateAsync(CreateUsuarioDto dto)
        {
            try
            {
                var (success, data, errorMessage) = await _http.PostAsync<UsuarioResponseDto>("/api/usuarios", dto);
                return (success, data, errorMessage);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool Success, UsuarioResponseDto? Usuario, string ErrorMessage)> UpdateAsync(string id, UpdateUsuarioDto dto)
        {
            try
            {
                var (success, data, errorMessage) = await _http.PutAsync<UsuarioResponseDto>($"/api/usuarios/{id}", dto);
                return (success, data, errorMessage);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool Success, string ErrorMessage)> DeleteAsync(string id)
        {
            try
            {
                return await _http.DeleteAsync($"/api/usuarios/{id}");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<List<string>> GetPerfisAsync()
        {
            try
            {
                var perfis = await _http.GetAsync<List<string>>("/api/usuarios/perfis");
                return perfis ?? new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }
    }
}