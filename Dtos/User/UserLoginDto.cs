using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.User
{
    public class UserLoginDto
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
