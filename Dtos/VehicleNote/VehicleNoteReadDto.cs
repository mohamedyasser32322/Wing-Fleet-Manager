using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.VehicleNote
{
    public class VehicleNoteReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
