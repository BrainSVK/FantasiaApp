using Fantasia.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace Fantasia.Client.Services.AuthService
{
    //inspiroval som sa od Patrick God z YT
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public async Task<Hrac> GetHrac()
        {
            if (await IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<Hrac>("api/auth/gethrac");
                return response!;
            }
            else
            {
                return null!;
            }
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity!.IsAuthenticated;
        }

        public async Task<ServiceResponse<string>> Login(LoginModel request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/login", request);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<string>>())!;
        }

        public async Task<ServiceResponse<int>> Register(RegisterModel request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/register", request);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<int>>())!;
        }

        public async Task<ServiceResponse<HracUpdate>> UpdateHrac(HracUpdate hrac)
        {
            var result = await _http.PutAsJsonAsync($"api/auth", hrac);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<HracUpdate>>();
            return content!;
        }

        public async Task VymazHraca()
        {
            await _http.DeleteAsync($"api/auth");
        }
    }
}
