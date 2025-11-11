using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public enum NotificationType
    {
        Task = 1,
        Reminder = 2,
    }

    public class Notification
    {
        public int Id { get; set; }
        [Required,Range(0,int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required]
        public NotificationType Type { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ReadAt { get; set; }
        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }
        public User CreatedTo { get; set; }
        public int CreatedToId { get; set; }
        public ICollection<FaultNotification> FaultNotifications { get; set; } = new List<FaultNotification>();
    }
}
