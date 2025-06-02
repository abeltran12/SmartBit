using SmartBit.Models;

namespace SmartBit.Repositories
{
    public interface IDepositRepository
    {
        Task<Deposit?> GetAsync(Guid id, string userId);
        Task<List<Deposit>> GetAllAsync(string userId);
        Task CreateAsync(Deposit deposit);
        Task<double> GetBalanceAsync(int month, string userId);
        Task<double> GetBalanceByMonetaryFundAsync(int month, string userId, Guid id);
        Task<List<Deposit>> GetBalanceByDatesAsync(DateTime fromDate, DateTime toDate, string userId);
    }
}