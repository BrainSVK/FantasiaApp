using Fantasia.Shared;

namespace Fantasia.Client.Services.UtokyService
{
    public interface IUtokyService
    {
        Task<FyzUtoky> GetFyzUtok(int Id);
        Task<MagUtoky> GetMagUtok(int Id);
        Task<VieUtoky> GetVieUtok(int Id);

    }
}
