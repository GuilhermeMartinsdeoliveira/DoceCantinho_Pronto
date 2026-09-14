using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;

namespace DoceCantinho.Desktop.Services
{
    public class DoceApiService
    {
        private readonly HttpClientHelper _http;

        public DoceApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        // ============================================================
        // LISTAR DOCES
        // ============================================================

        public async Task<List<DoceResponseDto>> GetAllAsync()
        {
            try
            {
                Debug.WriteLine(
                    "[DoceApiService] GET /api/doce");

                var doces =
                    await _http.GetAsync<List<DoceResponseDto>>(
                        "/api/doce");

                if (doces == null)
                {
                    Debug.WriteLine(
                        "[DoceApiService] API retornou null.");

                    return new List<DoceResponseDto>();
                }

                Debug.WriteLine(
                    $"[DoceApiService] {doces.Count} doces recebidos.");

                return doces;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "[DoceApiService] Erro ao listar doces:");
                Debug.WriteLine(ex);

                MessageBox.Show(
                    "Não foi possível carregar os produtos da API.\n\n" +
                    ex.Message,
                    "Erro ao carregar produtos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return new List<DoceResponseDto>();
            }
        }


        // ============================================================
        // BUSCAR DOCE POR ID
        // ============================================================

        public async Task<DoceResponseDto?> GetByIdAsync(int id)
        {
            try
            {
                Debug.WriteLine(
                    $"[DoceApiService] GET /api/doce/{id}");

                return await _http.GetAsync<DoceResponseDto>(
                    $"/api/doce/{id}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "[DoceApiService] Erro ao buscar doce:");
                Debug.WriteLine(ex);

                return null;
            }
        }


        // ============================================================
        // CRIAR DOCE
        // ============================================================

        public async Task<(
            bool Success,
            object? Data,
            string? ErrorMessage)> CreateAsync(
                CreateDoceDto dto)
        {
            try
            {
                Debug.WriteLine(
                    "[DoceApiService] POST /api/doce");

                var response =
                    await _http.PostAsync<object>(
                        "/api/doce",
                        dto);

                if (response.Success)
                {
                    Debug.WriteLine(
                        "[DoceApiService] Doce criado com sucesso.");

                    return (
                        true,
                        response.Data,
                        null);
                }

                Debug.WriteLine(
                    "[DoceApiService] Erro ao criar:");
                Debug.WriteLine(
                    response.ErrorMessage);

                return (
                    false,
                    null,
                    string.IsNullOrWhiteSpace(
                        response.ErrorMessage)
                        ? "Não foi possível criar o produto."
                        : response.ErrorMessage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "[DoceApiService] Exceção ao criar:");
                Debug.WriteLine(ex);

                return (
                    false,
                    null,
                    ex.Message);
            }
        }


        // ============================================================
        // ATUALIZAR DOCE
        // ============================================================

        public async Task<(
            bool Success,
            object? Data,
            string? ErrorMessage)> UpdateAsync(
                int id,
                UpdateDoceDto dto)
        {
            try
            {
                Debug.WriteLine(
                    $"[DoceApiService] PUT /api/doce/{id}");

                var response =
                    await _http.PutAsync<object>(
                        $"/api/doce/{id}",
                        dto);

                if (response.Success)
                {
                    Debug.WriteLine(
                        $"[DoceApiService] Doce {id} atualizado com sucesso.");

                    return (
                        true,
                        response.Data,
                        null);
                }

                Debug.WriteLine(
                    $"[DoceApiService] Erro ao atualizar doce {id}:");

                Debug.WriteLine(
                    response.ErrorMessage);

                return (
                    false,
                    null,
                    string.IsNullOrWhiteSpace(
                        response.ErrorMessage)
                        ? "Não foi possível atualizar o produto."
                        : response.ErrorMessage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"[DoceApiService] Exceção ao atualizar doce {id}:");

                Debug.WriteLine(ex);

                return (
                    false,
                    null,
                    ex.Message);
            }
        }


        // ============================================================
        // EXCLUIR DOCE
        // ============================================================

        public async Task<(
            bool Success,
            string ErrorMessage)> DeleteAsync(
                int id)
        {
            try
            {
                Debug.WriteLine(
                    $"[DoceApiService] DELETE /api/doce/{id}");

                var response =
                    await _http.DeleteAsync(
                        $"/api/doce/{id}");

                if (response.Success)
                {
                    Debug.WriteLine(
                        $"[DoceApiService] Doce {id} excluído.");

                    return (
                        true,
                        string.Empty);
                }

                return (
                    false,
                    string.IsNullOrWhiteSpace(
                        response.ErrorMessage)
                        ? "Não foi possível excluir o produto."
                        : response.ErrorMessage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "[DoceApiService] Exceção ao excluir:");

                Debug.WriteLine(ex);

                return (
                    false,
                    ex.Message);
            }
        }
    }
}