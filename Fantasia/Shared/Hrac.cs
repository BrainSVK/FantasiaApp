using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasia.Shared
{
    public class Hrac
    { 
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public Postava Postava { get; set; }
        public int PostavaId { get; set; }
    }
}
