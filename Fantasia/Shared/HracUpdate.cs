﻿using System.ComponentModel.DataAnnotations;

namespace Fantasia.Shared
{
    public class HracUpdate
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string NickName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        //[Required, MinLength(8)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
