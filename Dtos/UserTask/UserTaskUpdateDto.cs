using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.UserTask
{
    public class UserTaskUpdateDto
    {
        [Range(0, int.MaxValue)]
        public int? SerialNumber { get; set; }
        [StringLength(100)]
        public string? Title { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
