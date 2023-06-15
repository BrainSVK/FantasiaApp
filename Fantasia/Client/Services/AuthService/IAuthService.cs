using Fantasia.Shared;

namespace Fantasia.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(RegisterModel request);
        Task<ServiceResponse<string>> Login(LoginModel request);

        Task<Hrac> GetHrac();

        Task VymazHraca();

        Task<ServiceResponse<HracUpdate>> UpdateHrac(HracUpdate request);

        Task<bool> IsUserAuthenticated();
    }
}
