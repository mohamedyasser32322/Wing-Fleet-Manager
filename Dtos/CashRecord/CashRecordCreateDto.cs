using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.CashRecord
{
    public class CashRecordCreateDto
    {
        [Required, Range(0, int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required, Range(0, double.MaxValue)]
        public decimal Amount { get; set; }
        [Required]
        public CashOperationType OperationType { get; set; }
    }
}
