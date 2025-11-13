using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.Zone
{
    public class ZoneReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int SpareBatteries { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
