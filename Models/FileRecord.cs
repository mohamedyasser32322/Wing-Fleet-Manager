using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public class FileRecord
    {
        public int Id { get; set; }
        [Required,Range(0,int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required,StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }
        [Required,Url]
        public string FilePath { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
