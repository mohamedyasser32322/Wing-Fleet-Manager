using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public enum MovementType
    {
        Increase = 1,
        Decrease = 2,
    }
    public class SparePartMovement
    {
        public int Id { get; set; }
        [Required,Range(0,int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required]
        public MovementType Type { get; set; }
        [Required,Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        public bool? IsDeleted { get; set; }
        public SparePart SparePart { get; set; }
        public int SparePartId { get; set; }
        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }
        public Zone Zone { get; set; }
        public int ZoneId { get; set; }
    }
}
