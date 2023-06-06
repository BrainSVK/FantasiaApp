using Fantasia.Client.Services.AuthService;
using Fantasia.Shared;
using System.Net.Http.Json;

namespace Fantasia.Client.Services.UtokyService
{
    public class UtokyService : IUtokyService
    {
        private readonly HttpClient _http;
        private readonly IAuthService _authService;

        public UtokyService(HttpClient http, IAuthService authService)
        {
            //_localStorage = localStorage;
            _http = http;
            _authService = authService;
        }

        public async Task<FyzUtoky> GetFyzUtok(int Id)
        {
            if (await _authService.IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<FyzUtoky>($"api/utoky/getfyzutok?Id={Id}");
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<MagUtoky> GetMagUtok(int Id)
        {
            if (await _authService.IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<MagUtoky>($"api/utoky/getmagutok?Id={Id}");
                return response;
            }
            else
            {
                return null;
            }
        }

        public async Task<VieUtoky> GetVieUtok(int Id)
        {
            if (await _authService.IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<VieUtoky>($"api/utoky/getvieutok?Id={Id}");
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
