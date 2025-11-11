using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public enum VehicleAction
    {
        Fault = 1,
        Fix = 2,
    }
    public class VehicleLog
    {
        public int Id { get; set; }
        [Required]
        public VehicleAction Action { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
