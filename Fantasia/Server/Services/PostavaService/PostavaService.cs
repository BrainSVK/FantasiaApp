
namespace Fantasia.Server.Services.PostavaService
{
    public class PostavaService : IPostavaService
    {
        private readonly DataContext _context;

        public PostavaService(DataContext context)
        {
            _context = context;
        }

        public async Task<Postava> GetPostavaById(int Id)
        {
            var hrac = await _context.Hrac.FirstOrDefaultAsync(p => p.Id.Equals(Id));
            return (await _context.Postava.FirstOrDefaultAsync(p => p.Id.Equals(hrac!.PostavaId)))!;
        }

        public async Task<ServiceResponse<PostavaUpdate>> UpdatePostava(PostavaUpdate postava)
        {
            //var dbPostava = await GetPostavaById(postava.Id);
            var dbPostava = await _context.Postava.FirstOrDefaultAsync(p => p.Id.Equals(postava.Id));

            if (dbPostava == null)
            {
                return new ServiceResponse<PostavaUpdate>
                {
                    Success = false,
                    Message = "Postava neexistuje"
                };
            }       

            dbPostava.FyzickaSila = postava.FyzickaSila;
            dbPostava.MagickaSila = postava.MagickaSila;
            dbPostava.Viera = postava.Viera;
            dbPostava.Stamina = postava.Stamina;
            dbPostava.Vitalita = postava.Vitalita;
            dbPostava.Stastie = postava.Stastie;
            dbPostava.VolneStaty = postava.VolneStaty;
            dbPostava.FyzUtokyId = postava.FyzUtokyId;
            dbPostava.MagUtokyId = postava.MagUtokyId;
            dbPostava.VieUtokyId = postava.VieUtokyId;

            if (postava.Image == "zmen")
            {
                var dbImg = await _context.Image.FirstOrDefaultAsync(p => p.Img.Equals(dbPostava.Image));
                int id = 0;
                if (dbImg != null) {
                    id = dbImg.Id + 1;
                }
                if (id == 5)
                {
                    id = 1;
                }
                var dbDaj = await _context.Image.FirstOrDefaultAsync(p => p.Id.Equals(id));
                if (dbDaj != null)
                {
                    dbPostava.Image = dbDaj.Img;
                }
                postava.Image = dbPostava.Image;
            }

            await _context.SaveChangesAsync();
            return new ServiceResponse<PostavaUpdate> { Data = postava, Message = "Zmeny sa uskutocnili", Success = true }; ;
        }
    }
}
