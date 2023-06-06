using Fantasia.Server.Services.AuthService;
using Fantasia.Server.Data;
using Fantasia.Shared;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Stripe;
using System.Security.Cryptography;

namespace Fantasia.Server.Services.PostavaService
{
    public class PostavaService : IPostavaService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public PostavaService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<Postava> GetPostavaById(int Id)
        {
            return await _context.Postava.FirstOrDefaultAsync(p => p.Id.Equals(Id));
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
                int id = dbImg.Id + 1;
                if (id == 5)
                {
                    id = 1;
                }
                var dbDaj = await _context.Image.FirstOrDefaultAsync(p => p.Id.Equals(id));
                dbPostava.Image = dbDaj.Img;
                postava.Image = dbPostava.Image;
            }

            await _context.SaveChangesAsync();
            return new ServiceResponse<PostavaUpdate> { Data = postava, Message = "Zmeny sa uskutocnili", Success = true }; ;
        }
    }
}
