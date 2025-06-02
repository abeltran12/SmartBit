using Microsoft.EntityFrameworkCore;
using SmartBit.Data;
using SmartBit.Models;

namespace SmartBit.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepositRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Deposit deposit)
        {
            await _dbContext.AddAsync(deposit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Deposit>> GetAllAsync(string userId)
        {
             return await _dbContext.Deposit
                .Where(deposit => deposit.ApplicationUserId == userId)
                    .Select(deposit => new Deposit
                    {
                        Id = deposit.Id,
                        Amount = deposit.Amount,
                        Date = deposit.Date,
                        ApplicationUserId = deposit.ApplicationUserId,
                        MonetaryFundId = deposit.MonetaryFundId,
                        MonetaryFundName = deposit.MonetaryFund.Name
                    })
                .AsNoTracking()
                .OrderBy(deposit => deposit.Date)
                .ToListAsync();
        }

        public async Task<Deposit?> GetAsync(Guid id, string userId)
        {
            return await _dbContext.Deposit.FirstOrDefaultAsync
                (deposit => deposit.ApplicationUserId == userId &&
                    deposit.Id == id);
        }

        public async Task<double> GetBalanceAsync(int month, string userId)
        {
           return await _dbContext.Deposit
            .Where(deposit => deposit.ApplicationUserId == userId && deposit.Date.Month == month)
            .SumAsync(deposit => deposit.Amount);
        }

        public async Task<List<Deposit>> GetBalanceByDatesAsync(DateTime fromDate, DateTime toDate, string userId)
        {
            return await _dbContext.Deposit
                .Where(deposit => deposit.ApplicationUserId == userId
                    && deposit.Date >= fromDate && deposit.Date <= toDate)
                    .Select(deposit => new Deposit
                    {
                        Id = deposit.Id,
                        Amount = deposit.Amount,
                        Date = deposit.Date,
                        ApplicationUserId = deposit.ApplicationUserId,
                        MonetaryFundId = deposit.MonetaryFundId,
                        MonetaryFundName = deposit.MonetaryFund.Name
                    })
                .AsNoTracking()
                .OrderBy(deposit => deposit.Date)
                .ToListAsync();
        }

        public async Task<double> GetBalanceByMonetaryFundAsync(int month, string userId, Guid id)
        {
            return await _dbContext.Deposit
            .Where(deposit => deposit.ApplicationUserId == userId
                && deposit.Date.Month == month 
                && deposit.MonetaryFundId == id)
            .SumAsync(deposit => deposit.Amount);
        }
    }
}