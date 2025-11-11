using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public enum SparePartType
    {
        ScooterPart = 1,
        BikePart = 2,
        GolfCarPart = 3,
    }
    public class SparePart
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public SparePartType Type { get; set; }
        [Required, Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<SparePartMovement> SparePartMovements { get; set; } = new List <SparePartMovement>();
    }
}
