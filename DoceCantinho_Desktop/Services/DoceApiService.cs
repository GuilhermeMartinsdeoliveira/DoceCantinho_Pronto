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
                    "[DoceApiService] Buscando produtos em /api/doce");

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
                    $"[DoceApiService] Produtos recebidos: {doces.Count}");

                return doces;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    "[DoceApiService] ERRO ao carregar produtos: " + ex);

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
        // CRIAR DOCE
        // ============================================================

        public async Task<(
            bool Success,
            object? Data,
            string? ErrorMessage)> CreateAsync(object dto)
        {
            try
            {
                var response =
                    await _http.PostAsync<object>(
                        "/api/doce",
                        dto);

                if (response.Success)
                {
                    return (
                        true,
                        response.Data,
                        null);
                }

                return (
                    false,
                    null,
                    string.IsNullOrWhiteSpace(response.ErrorMessage)
                        ? "Não foi possível criar o produto."
                        : response.ErrorMessage);
            }
            catch (Exception ex)
            {
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
                object dto)
        {
            try
            {
                var response =
                    await _http.PutAsync<object>(
                        $"/api/doce/{id}",
                        dto);

                if (response.Success)
                {
                    return (
                        true,
                        response.Data,
                        null);
                }

                return (
                    false,
                    null,
                    string.IsNullOrWhiteSpace(response.ErrorMessage)
                        ? "Não foi possível atualizar o produto."
                        : response.ErrorMessage);
            }
            catch (Exception ex)
            {
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
            string ErrorMessage)> DeleteAsync(int id)
        {
            try
            {
                var response =
                    await _http.DeleteAsync(
                        $"/api/doce/{id}");

                if (response.Success)
                {
                    return (
                        true,
                        string.Empty);
                }

                return (
                    false,
                    string.IsNullOrWhiteSpace(response.ErrorMessage)
                        ? "Não foi possível excluir o produto."
                        : response.ErrorMessage);
            }
            catch (Exception ex)
            {
                return (
                    false,
                    ex.Message);
            }
        }
    }
}