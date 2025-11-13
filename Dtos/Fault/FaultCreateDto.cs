using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.Fault
{
    public class FaultCreateDto
    {
        [Required, Range(0, int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public FaultType Type { get; set; }
        [Required]
        public FaultPriority Priority { get; set; }
    }
}
