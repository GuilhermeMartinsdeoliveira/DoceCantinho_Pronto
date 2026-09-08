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

        public async Task<(bool Success, UserResponseDto? User, string ErrorMessage)>
            LoginAsync(string email, string password)
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

        public async Task<(bool Success, string ErrorMessage)>
            LogoutAsync()
        {
            var result =
                await _http.PostEmptyAsync("/api/auth/logout");

            _http.ClearCookies();

            return result;
        }

        public async Task<UserResponseDto?>
            GetCurrentUserAsync()
        {
            return await _http.GetAsync<UserResponseDto>(
                "/api/auth/me");
        }

        public async Task<
            (bool Success,
             UserResponseDto? User,
             string ErrorMessage)>
            UpdateProfileAsync(
                UpdateProfileRequestDto dto)
        {
            var result =
                await _http.PutAsync<UserResponseDto>(
                    "/api/auth/profile",
                    dto);

            return (
                result.Success,
                result.Data,
                result.ErrorMessage
            );
        }
    }
}