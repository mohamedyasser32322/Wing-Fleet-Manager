using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public enum FaultType
    {
        IotFault = 1,
        ControllerFault = 2,
        BatteryFault = 3,
        NetworkFault = 4,
        OtherFault = 5,
    } 
    public enum FaultPriority
    {
        Critical = 1,
        High = 2,
        Normal = 3,
    }
    public class Fault
    {
        public int Id { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int SerialNumber { get; set; } = 0000000;
        [Required,StringLength(100)]
        public string Title { get; set; }
        [Required,StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public FaultType Type { get; set; }
        [Required]
        public FaultPriority Priority { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSolved { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime SolvedAt { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public Zone Zone { get; set; }
        public int ZoneId { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public int? ClosedById { get; set; }
        public User ClosedBy { get; set; }
        public ICollection<FaultImg> FaultImgs { get; set; } = new List<FaultImg>();
        public ICollection<FaultNotification> FaultNotifications { get; set; } = new List<FaultNotification>();
    }
}
