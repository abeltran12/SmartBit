using SmartBit.Models;

namespace SmartBit.Repositories
{
    public interface IExpenseRepository
    {
        Task<Expense?> GetAsync(Guid id, string userId);
        Task<List<Expense>> GetAllAsync(string userId);
        Task CreateAsync(Expense expense);
        Task<List<Expense>> GetExpenseByDatesAsync(DateTime fromDate, DateTime toDate, string userId);
        Task<double> GetExpensesAsync(int month, string userId);
    }
}