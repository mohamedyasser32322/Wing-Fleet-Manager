using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.Zone
{
    public class ZoneCreateDto
    {
        [Required, StringLength(100, MinimumLength = 7)]
        public string Name { get; set; }
        [Required, StringLength(100, MinimumLength = 5)]
        public string City { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int SpareBatteries { get; set; }
    }
}
