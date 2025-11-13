using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.VehicleNote
{
    public class VehicleNoteCreateDto
    {
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }
    }
}
