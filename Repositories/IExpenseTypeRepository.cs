using SmartBit.Models;

namespace SmartBit.Repositories
{
    public interface IExpenseTypeRepository
    {
        Task<ExpenseType?> GetAsync(string id);
        Task<List<ExpenseType>> GetAllAsync();
        Task CreateAsync(ExpenseType expenseType);
        Task UpdateAsync(ExpenseType expenseType);
        Task DeleteAsync(string code);
        Task<string> GetLastCodeAsync();
    }
}