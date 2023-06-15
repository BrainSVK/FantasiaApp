
namespace Fantasia.Server.Services.PostavaService
{
    public interface IPostavaService
    {
        Task<Postava> GetPostavaById(int Id);

        Task<ServiceResponse<PostavaUpdate>> UpdatePostava(PostavaUpdate postava);
    }
}
