using System.ComponentModel.DataAnnotations;

namespace SmartBit.Models
{
    public class ExpenseDetail
    {
        public Guid Id { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public double Amount { get; set; }
        
        public Expense Expense { get; set; }

        [Required]
        public Guid ExpenseId { get; set; }

        public ExpenseType ExpenseType { get; set; }

        [Required]
        public string ExpenseTypeId { get; set; }
    }
}