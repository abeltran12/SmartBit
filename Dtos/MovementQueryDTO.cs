using SmartBit.Models;

namespace SmartBit.Dtos
{
    public class MovementQueryDTO
    {
        //Deposit
        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public string MonetaryFundName { get; set; } = string.Empty;

        //Expenses

        public string BusinessName { get; set; } = string.Empty;

        public DocumentType DocumentType { get; set; }

        public string Observations { get; set; } = string.Empty;

        public ICollection<ExpenseDetailsDTO> ExpenseDetails { get; set; } = [];

        public double TotalAmount => ExpenseDetails?.Sum(d => d.Amount) ?? 0;
        
        public bool Expense { get; set; }

    }
}