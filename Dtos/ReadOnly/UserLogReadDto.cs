using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.ReadOnly
{
    public class UserLogReadDto
    {
        public int Id { get; set; }
        public UserAction UserAction { get; set; }
        public DateTime ActionTime { get; set; }
    }
}
