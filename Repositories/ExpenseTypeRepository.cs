using Microsoft.EntityFrameworkCore;
using SmartBit.Data;
using SmartBit.Models;

namespace SmartBit.Repositories
{
    public class ExpenseTypeRepository : IExpenseTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpenseTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(ExpenseType expenseType)
        {
            await _dbContext.AddAsync(expenseType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var expenseType = await _dbContext.ExpenseTypes.FindAsync(code);
            expenseType!.Active = false;
            await UpdateAsync(expenseType);
        }

        public async Task<List<ExpenseType>> GetAllAsync()
        {
            return await _dbContext.ExpenseTypes
                .Where(x => x.Active == true)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ExpenseType?> GetAsync(string id)
        {
            return await _dbContext.ExpenseTypes.FindAsync(id);
        }

        public async Task UpdateAsync(ExpenseType expenseType)
        {
            _dbContext.Update(expenseType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> GetLastCodeAsync()
        {
            var allCodes = await _dbContext.ExpenseTypes
                .Where(x => !string.IsNullOrEmpty(x.Code))
                .Select(x => x.Code)
                .ToListAsync();

            int maxId = 0;
            
            foreach (var code in allCodes)
            {
                if (code.Length == 4 && int.TryParse(code, out int numericCode))
                {
                    maxId = Math.Max(maxId, numericCode);
                }
            }

            var nextCode = (maxId + 1).ToString("0000");
            return nextCode;
        }
    }
}