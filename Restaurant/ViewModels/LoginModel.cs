﻿using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class LoginModel
    {
        
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
