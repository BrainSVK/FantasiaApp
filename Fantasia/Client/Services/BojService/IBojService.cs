using Fantasia.Shared;

namespace Fantasia.Client.Services.BojService
{
    public interface IBojService
    {
        Task<ServiceResponse<Boj>> VytvorBoj(VytvorBoj vytvorBoj);

        Task<ServiceResponse<Boj>> GetBoj(int IdPostava);

        Task<ServiceResponse<Boj>> UpdateBoj(Boj boj);

        Task<ServiceResponse<bool>> DeleteBoj(Boj boj);
    }
}
