using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.Notification
{
    public class NotificationReadDto
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public NotificationType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}
