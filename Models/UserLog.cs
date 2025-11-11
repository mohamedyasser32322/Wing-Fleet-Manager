using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public enum UserAction
    {
        Add =1,
        Update =2,
        Delete =3,
    }
    public class UserLog
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        [Required]
        public UserAction UserAction { get; set; }
        public DateTime ActionTime { get; set; } = DateTime.UtcNow;
    }
}
