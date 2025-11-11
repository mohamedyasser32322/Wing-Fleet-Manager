using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wing_Fleet_Manager.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string FullName { get; set; }
        [Required, StringLength(100),EmailAddress]
        public string Email { get; set; }
        [StringLength(100)]
        public string? NickName { get; set; }
        [Required,StringLength(500)]
        public string? HashPassword { get; set; }
        [StringLength(50)]
        public string? Phone {  get; set; }
        [StringLength(500)]
        public string? ImageUrl { get; set; }
        
        [Required]
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpDatedAt { get; set; }
        public DateTime? LastLoginAt {  get; set; }
        public bool IsDeleted { get; set; } = false;

        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<UserZone> UserZones { get; set; } = new List<UserZone>();
        public ICollection<Notification> ReceivedNotifications { get; set; } = new List<Notification>();
        public ICollection<Notification> SentNotifications { get; set; } = new List<Notification>();
        public ICollection<UserLog> UserLogs { get; set; } = new List<UserLog>();
        public ICollection<UserTask> CreatedTasks { get; set; } = new List<UserTask>();
        public ICollection<UserTask> AssignedTasks { get; set; } = new List<UserTask>();
        public ICollection<CashRecord> CashRecords { get; set; } = new List<CashRecord>();
        public ICollection<FileRecord> FileRecords { get; set; } = new List<FileRecord>();
        public ICollection<Fault> FaultsCreated { get; set; } = new List<Fault>();
        public ICollection<Fault> FaultsClosed { get; set; } = new List<Fault>();
        public ICollection<SparePartMovement> SparePartMovements { get; set; } = new List<SparePartMovement>();
        public ICollection<VehicleNote> VehicleNotes { get; set; } = new List<VehicleNote>();
        public ICollection<VehicleLog> VehicleLogs { get; set; } = new List<VehicleLog>();
        public ICollection<TaskLog> TaskLogs { get; set; } = new List<TaskLog>();
    }
}
