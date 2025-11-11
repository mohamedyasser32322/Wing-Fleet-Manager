using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public class FaultImg
    {
        public int Id { get; set; }
        [Required,Url]
        public string ImgPath { get; set; }
        public Fault Fault { get; set; }
        public int FaultId { get; set; }
    }
}
