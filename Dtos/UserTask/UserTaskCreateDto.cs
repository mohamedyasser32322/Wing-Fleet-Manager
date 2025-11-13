using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.UserTask
{
    public class UserTaskCreateDto
    {
        [Required, Range(0, int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public bool? IsCompleted { get; set; }
    }
}
