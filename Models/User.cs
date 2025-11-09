using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string FullName { get; set; }
        [Required, StringLength(100),EmailAddress]
        public string Email { get; set; }
        [StringLength(100)]
        public string? NickName { get; set; }
        [Required,StringLength(500)]
        public string? HashPassword { get; set; }
        [StringLength(50)]
        public string? Phone {  get; set; }
        [StringLength(500)]
        public string? ImageUrl { get; set; }
        
        [Required]
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpDatedAt { get; set; }
        public DateTime? LastLoginAt {  get; set; }
        public bool IsDeleted { get; set; } = false;

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
