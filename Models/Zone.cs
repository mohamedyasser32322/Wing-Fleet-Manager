using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public class Zone
    {
        public int Id { get; set; }
        [Required,StringLength(100,MinimumLength =7)]
        public string Name { get; set; }
        [Required, StringLength(100, MinimumLength = 5)]
        public string City { get; set; }
        [Required,Range(0,int.MaxValue)]
        public int SpareBatteries { get; set; }
        public bool? IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; }
        public ICollection<UserZone>UserZones { get; set; } = new List<UserZone>();
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public ICollection<Fault> Faults { get; set; } = new List<Fault>();
        public ICollection<CashRecord> CashRecords { get; set; } = new List<CashRecord>();
        public ICollection<SparePartMovement> SparePartMovements { get; set;} = new List<SparePartMovement>();
    }
}
