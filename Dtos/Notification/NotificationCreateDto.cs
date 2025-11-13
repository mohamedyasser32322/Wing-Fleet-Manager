using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.Notification
{
    public class NotificationCreateDto
    {
        [Required, Range(0, int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required]
        public NotificationType Type { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }
        public bool? IsRead { get; set; }
    }
}
