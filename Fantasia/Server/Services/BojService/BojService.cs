
namespace Fantasia.Server.Services.BojService
{
    public class BojService : IBojService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public BojService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<Boj>> GetBoj(int IdPostava)
        {
            var result = await _context.Boj.FirstOrDefaultAsync(b => b.IdPostava.Equals(IdPostava));

            if (result == null) {
                return new ServiceResponse<Boj>
                {
                    Success = false,
                    Message = "Hrac uz je v Boji"
                };
            }

            return new ServiceResponse<Boj> { Data = result, Message = "Dostal si sa do Boja", Success = true};
        }

        public async Task<ServiceResponse<Boj>> VytvorBoj(VytvorBoj vytvorBoj)
        {
            var postava = await _context.Postava.FirstOrDefaultAsync(p => p.Id.Equals(vytvorBoj.Id));

            var zhoda = await _context.Boj.FirstOrDefaultAsync(b => b.IdPostava.Equals(vytvorBoj.Id));

            if (zhoda != null) {
                return new ServiceResponse<Boj>
                {
                    Success = false,
                    Message = "Hrac uz je v Boji"
                };
            }

            Random rnd = new Random();

            var boj = new Boj();

            if (postava != null)
            {
                boj = new Shared.Boj
                {
                    IdPostava = vytvorBoj.Id,
                    Obtiaznost = vytvorBoj.Obtiaznost,
                    MaxZ = postava.Vitalita * 10,
                    AktZ = postava.Vitalita * 10,
                    MaxZNep = vytvorBoj.Obtiaznost * 100,
                    AktZNep = vytvorBoj.Obtiaznost * 100,
                    RandSilaUtok = rnd.Next(vytvorBoj.Obtiaznost * 10 - (int)(vytvorBoj.Obtiaznost * 0.2 * 10), vytvorBoj.Obtiaznost * 10 + (int)(vytvorBoj.Obtiaznost * 0.2 * 10)),
                };
            }

            _context.Boj.Add(boj);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Boj> { Data = boj, Message = "Boj sa vytvoril", Success = true };
        }

        public async Task<ServiceResponse<Boj>> UpdateBoj(Boj boj)
        {
            //var dbPostava = await GetPostavaById(postava.Id);
            var dbBoj = await _context.Boj.FirstOrDefaultAsync(b => b.Id.Equals(boj.Id));

            if (dbBoj == null)
            {
                return new ServiceResponse<Boj>
                {
                    Success = false,
                    Message = "Postava neexistuje"
                };
            }

            dbBoj.AktZNep = boj.AktZNep;
            dbBoj.AktZ = boj.AktZ;

            await _context.SaveChangesAsync();
            return new ServiceResponse<Boj> { Data = boj, Message = "Zmeny sa uskutocnili", Success = true }; ;
        }

        public async Task<ServiceResponse<bool>> DeleteBoj(int Id)
        {
            var dbBoj = await _context.Boj.FirstOrDefaultAsync(p => p.Id.Equals(Id));

            if (dbBoj == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Product not found."
                };
            }

            _context.Boj.Remove(dbBoj);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };

        }
    }
}
