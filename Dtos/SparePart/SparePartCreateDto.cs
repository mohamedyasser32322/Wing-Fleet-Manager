using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.SparePart
{
    public class SparePartCreateDto
    {
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public SparePartType Type { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
