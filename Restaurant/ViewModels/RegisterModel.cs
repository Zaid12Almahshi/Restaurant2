using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class RegisterModel
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "not match")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
    }
}
