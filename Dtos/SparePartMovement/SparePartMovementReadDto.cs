using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.SparePartMovement
{
    public class SparePartMovementReadDto
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public MovementType Type { get; set; }
        public int Quantity { get; set; }
    }
}
