using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public class VehicleNote
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
    }
}
