using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoceCantinho.Desktop.Services
{
    public class BlogApiService
    {
        private readonly HttpClientHelper _http;

        public BlogApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        // ============================================================
        // LISTAR
        // GET /api/blog
        // ============================================================

        public async Task<(
            bool Success,
            List<BlogPostResponseDto> Data,
            string ErrorMessage)> GetAllAsync()
        {
            try
            {
                var response =
                    await _http.GetAsync<List<BlogPostResponseDto>>(
                        "/api/blog"
                    );

                return (
                    true,
                    response ?? new List<BlogPostResponseDto>(),
                    string.Empty
                );
            }
            catch (Exception ex)
            {
                return (
                    false,
                    new List<BlogPostResponseDto>(),
                    ex.Message
                );
            }
        }

        // ============================================================
        // BUSCAR POR ID
        // GET /api/blog/{id}
        // ============================================================

        public async Task<(
            bool Success,
            BlogPostResponseDto? Data,
            string ErrorMessage)> GetByIdAsync(int id)
        {
            try
            {
                var response =
                    await _http.GetAsync<BlogPostResponseDto>(
                        $"/api/blog/{id}"
                    );

                if (response == null)
                {
                    return (
                        false,
                        null,
                        "Publicação não encontrada."
                    );
                }

                return (
                    true,
                    response,
                    string.Empty
                );
            }
            catch (Exception ex)
            {
                return (
                    false,
                    null,
                    ex.Message
                );
            }
        }

        // ============================================================
        // CRIAR
        // POST /api/blog
        // ============================================================

        public async Task<(
            bool Success,
            BlogPostResponseDto? Data,
            string ErrorMessage)> CreateAsync(
                CreateBlogPostDto dto)
        {
            try
            {
                var response =
                    await _http.PostAsync<BlogPostResponseDto>(
                        "/api/blog",
                        dto
                    );

                if (response.Success)
                {
                    return (
                        true,
                        response.Data,
                        string.Empty
                    );
                }

                return (
                    false,
                    null,
                    string.IsNullOrWhiteSpace(
                        response.ErrorMessage)
                        ? "Não foi possível criar a publicação."
                        : response.ErrorMessage
                );
            }
            catch (Exception ex)
            {
                return (
                    false,
                    null,
                    ex.Message
                );
            }
        }

        // ============================================================
        // EDITAR
        // PUT /api/blog/{id}
        // ============================================================

        public async Task<(
            bool Success,
            BlogPostResponseDto? Data,
            string ErrorMessage)> UpdateAsync(
                int id,
                UpdateBlogPostDto dto)
        {
            try
            {
                var response =
                    await _http.PutAsync<BlogPostResponseDto>(
                        $"/api/blog/{id}",
                        dto
                    );

                if (response.Success)
                {
                    return (
                        true,
                        response.Data,
                        string.Empty
                    );
                }

                return (
                    false,
                    null,
                    string.IsNullOrWhiteSpace(
                        response.ErrorMessage)
                        ? "Não foi possível atualizar a publicação."
                        : response.ErrorMessage
                );
            }
            catch (Exception ex)
            {
                return (
                    false,
                    null,
                    ex.Message
                );
            }
        }

        // ============================================================
        // EXCLUIR
        // DELETE /api/blog/{id}
        // ============================================================

        public async Task<(
            bool Success,
            string ErrorMessage)> DeleteAsync(int id)
        {
            try
            {
                var response =
                    await _http.DeleteAsync(
                        $"/api/blog/{id}"
                    );

                if (response.Success)
                {
                    return (
                        true,
                        string.Empty
                    );
                }

                return (
                    false,
                    string.IsNullOrWhiteSpace(
                        response.ErrorMessage)
                        ? "Não foi possível excluir a publicação."
                        : response.ErrorMessage
                );
            }
            catch (Exception ex)
            {
                return (
                    false,
                    ex.Message
                );
            }
        }
    }
}