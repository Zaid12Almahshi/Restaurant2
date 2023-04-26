using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class UsersModel
    {
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
