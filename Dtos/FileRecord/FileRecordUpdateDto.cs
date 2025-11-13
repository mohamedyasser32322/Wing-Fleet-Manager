using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.FileRecord
{
    public class FileRecordUpdateDto
    {
        [Range(0, int.MaxValue)]
        public int? SerialNumber { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        [Url]
        public string? FilePath { get; set; }
    }
}
