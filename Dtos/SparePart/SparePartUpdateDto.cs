using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.SparePart
{
    public class SparePartUpdateDto
    {
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        public SparePartType? Type { get; set; }
        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }
    }
}
