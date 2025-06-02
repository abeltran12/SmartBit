using SmartBit.Models;

namespace SmartBit.Services
{
    public interface IExpendService
    {
        Task<Expense?> GetAsync(Guid id);
        Task<List<Expense>> GetAllAsync();
        Task CreateAsync(Expense expense);
    }
}