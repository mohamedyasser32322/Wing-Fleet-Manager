using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.User
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? NickName { get; set; }
        public string? Phone { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLoginAt { get; set; }
        public string RoleName { get; set; }
    }
}
