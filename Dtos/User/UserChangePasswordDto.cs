using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.User
{
    public class UserChangePasswordDto
    {
        [Required]
        public int Id { get; set; }
        [Required , StringLength(500,MinimumLength =8)]
        public string CurrentPassword { get; set; }
        [Required , StringLength(500,MinimumLength =8)]
        public string NewPassword { get; set; }
        [Required , StringLength(500,MinimumLength =8)]
        [Compare("NewPassword",ErrorMessage = "Password Doesn't Match")]
        public string ConfirmNewPassword { get; set; }
    }
}
