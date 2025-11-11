using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public enum Status
    {
        Assighned = 1,
        Completed = 2,
    }
    public class TaskLog
    {
        public int Id { get; set; }
        [Required]
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public UserTask UserTask { get; set; }
        public int UserTaskId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
