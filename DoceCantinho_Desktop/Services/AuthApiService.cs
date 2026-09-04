using DoceCantinho.Desktop.DTOs;
using DoceCantinho.Desktop.Helpers;

namespace DoceCantinho.Desktop.Services
{
    public class AuthApiService
    {
        private readonly HttpClientHelper _http;

        public AuthApiService()
        {
            _http = HttpClientHelper.Instance;
        }

        // ============================================================
        // LOGIN
        // ============================================================

        public async Task<(bool Success, UserResponseDto? User, string ErrorMessage)>
            LoginAsync(
                string email,
                string password)
        {
            var loginDto = new LoginRequestDto
            {
                Email = email,
                Password = password
            };

            var (success, data, error) =
                await _http.PostAsync<UserResponseDto>(
                    "/api/auth/login",
                    loginDto);

            return (success, data, error);
        }

        // ============================================================
        // LOGOUT
        // ============================================================

        public async Task<(bool Success, string ErrorMessage)>
            LogoutAsync()
        {
            var result =
                await _http.PostEmptyAsync(
                    "/api/auth/logout");

            _http.ClearCookies();

            return result;
        }

        // ============================================================
        // USUÁRIO ATUAL
        // ============================================================

        public async Task<UserResponseDto?>
            GetCurrentUserAsync()
        {
            return await _http.GetAsync<UserResponseDto>(
                "/api/auth/me");
        }

        // ============================================================
        // ATUALIZAR PERFIL
        // ============================================================

        public async Task<
            (bool Success,
             UserResponseDto? User,
             string ErrorMessage)>
            UpdateProfileAsync(
                string email,
                string currentPassword,
                string? newPassword,
                string? confirmPassword)
        {
            var dto =
                new UpdateProfileRequestDto
                {
                    Email = email,

                    CurrentPassword =
                        string.IsNullOrWhiteSpace(currentPassword)
                            ? null
                            : currentPassword,

                    NewPassword =
                        string.IsNullOrWhiteSpace(newPassword)
                            ? null
                            : newPassword,

                    ConfirmPassword =
                        string.IsNullOrWhiteSpace(confirmPassword)
                            ? null
                            : confirmPassword
                };

            return await _http.PutAsync<UserResponseDto>(
                "/api/auth/profile",
                dto);
        }
    }
}