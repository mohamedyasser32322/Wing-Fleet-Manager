using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public enum VehicleCompany
    {
        KuickWheel = 1,
        Navee = 2,
    }
    public enum VehicleType
    {
        Scooter = 1,
        Bike = 2,
        GolfCar = 3,
    }
    public enum VehicleStatus
    {
        Working = 1,
        Faulty = 2,
        UnderMaintenance = 3
    }
    public class Vehicle
    {
        public int Id { get; set; }
        [Required,StringLength(50,MinimumLength =3)]
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
        [Required]
        public VehicleStatus Status { get; set; }
        public bool IsDeleted { get; set; }= false;
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public Zone Zone { get; set; }
        public int ZoneId { get; set; }
        public ICollection<VehicleLog> VehicleLogs { get; set; } = new List<VehicleLog>();
        public ICollection<VehicleNote> VehicleNotes { get; set; } = new List<VehicleNote>();
        public ICollection<Fault> Faults { get; set; } = new List<Fault>();
        public ICollection<UserTask> Tasks { get; set; } = new List<UserTask>();
    }
}
