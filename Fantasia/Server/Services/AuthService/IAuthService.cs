using Fantasia.Shared;
using System.Net;

namespace Fantasia.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(Hrac hrac, string password);
        Task<bool> UserExists(string nickname);
        Task<ServiceResponse<string>> Login(string nickname, string password);
        Task<ServiceResponse<bool>> ChangePassword(int hracId, string newPassword);
        int GetUserId();
        string GetUserNickName();
        Task<Hrac> GetUserById(int Id);

        Task<ServiceResponse<bool>> VymazHraca(int Id);
        Task<ServiceResponse<HracUpdate>> UpdateHrac(HracUpdate hrac);


    }
}
