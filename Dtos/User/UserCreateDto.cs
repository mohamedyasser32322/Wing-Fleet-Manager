using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.User
{
    public class UserCreateDto
    {
        [Required, StringLength(100)]
        public string FullName { get; set; }
        [Required, StringLength(100), EmailAddress]
        public string Email { get; set; }
        [StringLength(100)]
        public string? NickName { get; set; }
        [Required, StringLength(500,MinimumLength =8)]
        public string Password { get; set; }
        [Required, StringLength(500, MinimumLength = 8)]
        [Compare("Password",ErrorMessage ="Password Doesn't Match")]
        public string ConfirmPassword { get; set; }
        [StringLength(50)]
        public string? Phone { get; set; }
        [StringLength(500)]
        public string? ImageUrl { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
