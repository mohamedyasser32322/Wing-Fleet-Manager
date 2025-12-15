using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.Fault
{
    public class FaultUpdateDto
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string? Title { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        public FaultType? Type { get; set; }
        public FaultPriority? Priority { get; set; }
        public bool IsSolved { get; set; }
    }
}
