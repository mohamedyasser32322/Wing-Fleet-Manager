using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Name { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
