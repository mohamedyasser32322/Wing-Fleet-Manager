using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        [Required,Range(0,int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required,StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime CompletedAt { get; set; }
        public bool? IsDeleted {  get; set; }

        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }
        public User AssignedTo { get; set; }
        public int AssignedToId { get; set; }

        public Vehicle Vehicle { get; set; }
        public int? VehicleId { get; set; }
        public ICollection<TaskLog> TaskLogs { get; set; }= new List<TaskLog>();
    }
}
