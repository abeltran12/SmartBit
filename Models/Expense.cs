using System.ComponentModel.DataAnnotations;
using SmartBit.Data;

namespace SmartBit.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        [StringLength(200)]
        public string BusinessName { get; set; } = string.Empty;
        
        [Required]
        public DocumentType DocumentType { get; set; }
        
        [StringLength(500)]
        public string Observations { get; set; } = string.Empty;
        
        public MonetaryFund MonetaryFund { get; set; }
        
        [Required]
        [Range(typeof(Guid), "00000001-0000-0000-0000-000000000000", "ffffffff-ffff-ffff-ffff-ffffffffffff", 
        ErrorMessage = "Please select a valid Monetary Fund")]
        public Guid MonetaryFundId { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;
        
        public ICollection<ExpenseDetail> ExpenseDetails { get; set; } = [];
    
        public double TotalAmount => ExpenseDetails?.Sum(d => d.Amount) ?? 0;
    }
}