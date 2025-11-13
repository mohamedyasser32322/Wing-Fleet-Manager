using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.Vehicle
{
    public class VehicleUpdateDto
    {
        [StringLength(50, MinimumLength = 3)]
        public string? Qr { get; set; }
        public VehicleType? Type { get; set; }
        public VehicleCompany? Company { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string? Imei { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string? Mac { get; set; }
        public bool? IsActive { get; set; }
        public VehicleStatus? Status { get; set; }
    }
}
