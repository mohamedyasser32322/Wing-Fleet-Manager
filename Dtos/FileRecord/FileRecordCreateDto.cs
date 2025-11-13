using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Dtos.FileRecord
{
    public class FileRecordCreateDto
    {
        [Required, Range(0, int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }
        [Required, Url]
        public string FilePath { get; set; }
    }
}
