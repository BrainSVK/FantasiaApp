using Fantasia.Shared;

namespace Fantasia.Server.Services.UtokyService
{
    public interface IUtokyService
    {
        Task<FyzUtoky> GetFyzUtokByPostavaId(int Id);
        Task<MagUtoky> GetMagUtokByPostavaId(int Id);
        Task<VieUtoky> GetVieUtokByPostavaId(int Id);
    }
}
