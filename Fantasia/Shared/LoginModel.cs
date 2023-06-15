using System.ComponentModel.DataAnnotations;

namespace Fantasia.Shared
{
    public class LoginModel
    {
        [Required]
        public string NickName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
