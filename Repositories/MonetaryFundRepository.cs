using Microsoft.EntityFrameworkCore;
using SmartBit.Data;
using SmartBit.Models;

namespace SmartBit.Repositories
{
    public class MonetaryFundRepository : IMonetaryFundRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MonetaryFundRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(MonetaryFund monetaryFund)
        {
            monetaryFund.Active = true;
            await _dbContext.AddAsync(monetaryFund);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var monetaryFund = await _dbContext.MonetaryFund.FindAsync(id);
            monetaryFund!.Active = false;
            await UpdateAsync(monetaryFund);
        }

        public async Task<List<MonetaryFund>> GetAllAsync()
        {
            return await _dbContext.MonetaryFund
                .Where(x => x.Active)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<MonetaryFund?> GetAsync(Guid id)
        {
            return await _dbContext.MonetaryFund.FindAsync(id);
        }

        public async Task UpdateAsync(MonetaryFund monetaryFund)
        {
            _dbContext.Update(monetaryFund);
            await _dbContext.SaveChangesAsync();
        }
    }
}