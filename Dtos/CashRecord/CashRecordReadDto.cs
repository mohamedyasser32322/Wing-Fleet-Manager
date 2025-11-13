using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.CashRecord
{
    public class CashRecordReadDto
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public decimal Amount { get; set; }
        public CashOperationType OperationType { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
