
namespace Fantasia.Server.Services.UtokyService
{
    public class UtokyService : IUtokyService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public UtokyService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<FyzUtoky> GetFyzUtokByPostavaId(int Id)
        {
            return (await _context.FyzUtoky.FirstOrDefaultAsync(u => u.Id.Equals(Id)))!;
        }

        public async Task<MagUtoky> GetMagUtokByPostavaId(int Id)
        {
            return (await _context.MagUtoky.FirstOrDefaultAsync(u => u.Id.Equals(Id)))!;
        }

        public async Task<VieUtoky> GetVieUtokByPostavaId(int Id)
        {
            return (await _context.VieUtoky.FirstOrDefaultAsync(u => u.Id.Equals(Id)))!;
        }
    }
}
