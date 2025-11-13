using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.FileRecord
{
    public class FileRecordReadDto
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
