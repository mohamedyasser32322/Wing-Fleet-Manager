using System.ComponentModel.DataAnnotations;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Dtos.CashRecord
{
    public class CashRecordUpdateDto
    {
        [Range(0, int.MaxValue)]
        public int? SerialNumber { get; set; }
        [Range(0, double.MaxValue)]
        public decimal? Amount { get; set; }
        public CashOperationType? OperationType { get; set; }
    }
}
