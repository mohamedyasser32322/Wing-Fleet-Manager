using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.User
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        [StringLength(100), EmailAddress]
        public string Email { get; set; }
        [StringLength(100)]
        public string? NickName { get; set; }
        [StringLength(50)]
        public string? Phone { get; set; }
        [StringLength(500)]
        public string? ImageUrl { get; set; }
        public bool? IsActive { get; set; }
        public int? RoleId { get; set; }
    }
}
