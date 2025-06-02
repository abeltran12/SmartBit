using SmartBit.Models;

namespace SmartBit.Services
{
    public interface IDepositService
    {
        Task<Deposit?> GetAsync(Guid id);
        Task<List<Deposit>> GetAllAsync();
        Task CreateAsync(Deposit deposit);
    }
}