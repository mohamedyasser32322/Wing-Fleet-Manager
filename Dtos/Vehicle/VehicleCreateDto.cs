using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.Vehicle
{
    public class VehicleCreateDto
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string Qr { get; set; }
        [Required]
        public VehicleType Type { get; set; }
        [Required]
        public VehicleCompany Company { get; set; }
        [Required, StringLength(100, MinimumLength = 3)]
        public string Imei { get; set; }
        [Required, StringLength(100, MinimumLength = 3)]
        public string Mac { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public int? ZoneId { get; set; }
        [Required]
        public VehicleStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
