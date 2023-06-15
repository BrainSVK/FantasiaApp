using Fantasia.Shared;
using System.Net.Http.Json;

namespace Fantasia.Client.Services.PostavaService
{
    public class PostavaService : IPostavaService
    {
        private readonly HttpClient _http;
        private readonly IAuthService _authService;

        public PostavaService(HttpClient http, IAuthService authService)
        {
            _http = http;
            _authService = authService;
        }

        //public event Action OnChange;

        public async Task<Postava> GetPostava()
        {
            if (await _authService.IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<Postava>("api/postava/getpostava");
                return response!;
            }
            else {
                return null!;
            }
        }

        public async Task<ServiceResponse<PostavaUpdate>> UpdatePostava(PostavaUpdate postava)
        {
            if (await _authService.IsUserAuthenticated())
            {
                var result = await _http.PutAsJsonAsync($"api/postava", postava);
                var content = await result.Content.ReadFromJsonAsync<ServiceResponse<PostavaUpdate>>();
                return content!;
            }
            else
            {
                return null!;
            }
        }
    }

}
