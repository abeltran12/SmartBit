using SmartBit.Models;

namespace SmartBit.Services
{
    public interface IMonetaryFundService
    {
        Task<MonetaryFund?> GetAsync(Guid id);
        Task<List<MonetaryFund>> GetAllAsync();
        Task CreateAsync(MonetaryFund monetaryFund);
        Task UpdateAsync(MonetaryFund monetaryFund);
        Task DeleteAsync(Guid id);
    }
}