using System.ComponentModel.DataAnnotations;

namespace Wing_Fleet_Manager.Models
{
    public enum CashOperationType
    {
        Income = 1,
        Expense = 2,
    }
    public class CashRecord
    {
        public int Id { get; set; }
        [Required,Range(0,int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required,Range(0,double.MaxValue)]
        public decimal Amount { get; set; }
        [Required]
        public CashOperationType OperationType { get; set; }

        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
        public bool? IsDeleted { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Zone Zone { get; set; }
        public int ZoneId { get; set; }
    }
}
