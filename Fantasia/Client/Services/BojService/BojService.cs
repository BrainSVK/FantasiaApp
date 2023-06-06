using Fantasia.Shared;
using System.Net.Http.Json;

namespace Fantasia.Client.Services.BojService
{
    public class BojService : IBojService
    {
        private readonly HttpClient _http;
        private readonly IAuthService _authService;

        Postava _postava { get; set; }
        public BojService(HttpClient http, IAuthService authService)
        {
            //_localStorage = localStorage;
            _http = http;
            _authService = authService;
        }

        public async Task<ServiceResponse<Boj>> VytvorBoj(VytvorBoj vytvorBoj)
        {
            var result = await _http.PostAsJsonAsync("api/boj/vytvor", vytvorBoj);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Boj>>();
            return content;
        }

        public async Task<ServiceResponse<Boj>> GetBoj(int IdPostava)
        {
                var response = await _http.GetFromJsonAsync<ServiceResponse<Boj>>($"api/boj/getboj?IdPostava={IdPostava}");
                return response;
        }

        public async Task<ServiceResponse<Boj>> UpdateBoj(Boj Boj)
        {
            if (await _authService.IsUserAuthenticated())
            {
                var result = await _http.PutAsJsonAsync($"api/boj", Boj);
                var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Boj>>();
                return content;
            }
            else
            {
                return null;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteBoj(Boj boj)
        {
            var result = await _http.DeleteAsync($"api/boj?Id={boj.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            return content;
        }
    }
}
