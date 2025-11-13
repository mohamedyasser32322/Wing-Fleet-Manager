using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.SparePartMovement
{
    public class SparePartMovementCreateDto
    {
        [Required, Range(0, int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required]
        public MovementType Type { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
