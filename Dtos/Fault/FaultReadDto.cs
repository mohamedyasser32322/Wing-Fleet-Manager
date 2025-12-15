using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.Fault
{
    public class FaultReadDto
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public FaultType Type { get; set; }
        public FaultPriority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime SolvedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSolved {  get; set; }
        public string VehicleQr {  get; set; }
    }
}
