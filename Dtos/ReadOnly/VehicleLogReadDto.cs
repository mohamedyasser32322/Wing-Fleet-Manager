using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.ReadOnly
{
    public class VehicleLogReadDto
    {
        public int Id { get; set; }
        public VehicleAction Action { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
