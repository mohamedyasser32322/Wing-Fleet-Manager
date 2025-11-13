using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.Vehicle
{
    public class VehicleReadDto
    {
        public int Id { get; set; }
        public string Qr { get; set; }
        public VehicleType Type { get; set; }
        public VehicleCompany Company { get; set; }
        public string Imei { get; set; }
        public string Mac { get; set; }
        public bool IsActive { get; set; }
        public VehicleStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
