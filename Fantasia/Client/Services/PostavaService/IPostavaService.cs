using Fantasia.Shared;

namespace Fantasia.Client.Services.PostavaService
{
    public interface IPostavaService
    {
        //event Action OnChange;
        Task<Postava> GetPostava();

        Task<ServiceResponse<PostavaUpdate>> UpdatePostava(PostavaUpdate postava);
    }
}
