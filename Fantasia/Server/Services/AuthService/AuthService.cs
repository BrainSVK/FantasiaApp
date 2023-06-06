using Azure.Core;
using Fantasia.Client.Pages;
using Fantasia.Server.Data;
using Fantasia.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Fantasia.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(DataContext context,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public string GetUserNickName() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

        public async Task<ServiceResponse<string>> Login(string nickName, string password)
        {
            var response = new ServiceResponse<string>();
            var hrac = await _context.Hrac
                .FirstOrDefaultAsync(x => x.NickName.ToLower().Equals(nickName.ToLower()));
            if (hrac == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, hrac.PasswordHash, hrac.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Data = CreateToken(hrac);
            }


            return response;
        }

        public async Task<ServiceResponse<int>> Register(Hrac _hrac, string password)
        {
            if (await UserExists(_hrac.NickName))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            _hrac.PasswordHash = passwordHash;
            _hrac.PasswordSalt = passwordSalt;

            var postava = new Shared.Postava
            {
                Image = "/imgHracov/postava2.png",
                FyzickaSila = 10,
                MagickaSila = 10,
                Viera = 10,
                Stamina = 10,
                Vitalita = 10,
                Stastie = 10,
                VolneStaty = 0,
                FyzUtokyId = 1,
                MagUtokyId = 1,
                VieUtokyId = 1
            };

            _context.Postava.Add(postava);
            await _context.SaveChangesAsync();

            var hrac = new Hrac
            {
                NickName = _hrac.NickName,
                Email = _hrac.Email,
                PasswordHash = _hrac.PasswordHash,
                PasswordSalt = _hrac.PasswordSalt,
                PostavaId = _context.Postava.Max(postava => postava.Id)
            };

            _context.Hrac.Add(hrac);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = hrac.Id, Message = "Registration successful!" };
        }

        public async Task<bool> UserExists(string nickName)
        {
            if (await _context.Hrac.AnyAsync(user => user.NickName.ToLower()
                 .Equals(nickName.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public async Task<ServiceResponse<bool>> ChangePassword(int hracId, string newPassword)
        {
            var user = await _context.Hrac.FindAsync(hracId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Password has been changed." };
        }

        private string CreateToken(Hrac hrac)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, hrac.Id.ToString()),
                new Claim(ClaimTypes.Name, hrac.NickName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<Hrac> GetUserById(int Id)
        {
            return await _context.Hrac.FirstOrDefaultAsync(h => h.Id.Equals(Id));
        }

        public async Task<ServiceResponse<HracUpdate>> UpdateHrac(HracUpdate hrac)
        {
            var dbHrac = await _context.Hrac.FirstOrDefaultAsync(h => h.Id.Equals(hrac.Id));

            if (dbHrac == null)
            {
                return new ServiceResponse<HracUpdate>
                {
                    Success = false,
                    Message = "Hrac neexistuje"
                };
            }

            if (await UserExists(hrac.NickName) && dbHrac.NickName != hrac.NickName)
            {
                return new ServiceResponse<HracUpdate>
                {
                    Success = false,
                    Message = "NickName sa uz pouziva"
                };
            }

            if (hrac.NickName != dbHrac.NickName)
            {
                dbHrac.NickName = hrac.NickName;
            }

            if (hrac.Email != dbHrac.Email)
            {
                dbHrac.Email = hrac.Email;
            }

            if (hrac.Password == hrac.ConfirmPassword &&  hrac.Password != "" && hrac.ConfirmPassword != "") {
                if (hrac.Password.Length >= 8)
                {
                    CreatePasswordHash(hrac.Password, out byte[] passwordHash, out byte[] passwordSalt);

                    dbHrac.PasswordHash = passwordHash;
                    dbHrac.PasswordSalt = passwordSalt;
                }
                else {
                    return new ServiceResponse<HracUpdate>
                    {
                        Success = false,
                        Message = "Heslo musi obsahovať aspoň 8 znakov"
                    };
                }
            }

            await _context.SaveChangesAsync();
            return new ServiceResponse<HracUpdate> { Data = hrac, Message = "Zmeny sa uskutocnili", Success = true };
        }

        public async Task<ServiceResponse<bool>> VymazHraca(int Id)
        {

            var dbHrac = await _context.Hrac.FirstOrDefaultAsync(h => h.Id.Equals(Id));   
            var dbPostava = await _context.Postava.FirstOrDefaultAsync(p => p.Id.Equals(Id));
            var dbBoj = await _context.Boj.FirstOrDefaultAsync(p => p.IdPostava.Equals(Id));

            if (dbHrac == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Hrac neexistuje"
                };
            }

            if (dbBoj != null)
            {
                _context.Boj.Remove(dbBoj);

            }

            _context.Hrac.Remove(dbHrac);
            _context.Postava.Remove(dbPostava);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };


        }
    }
}
