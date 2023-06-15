
namespace Fantasia.Shared
{
    public class Hrac
    { 
        public int Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public Postava Postava { get; set; } = new Postava();
        public int PostavaId { get; set; }
    }
}
