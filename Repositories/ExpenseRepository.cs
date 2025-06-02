using System.Data;
using Microsoft.EntityFrameworkCore;
using SmartBit.Data;
using SmartBit.Models;

namespace SmartBit.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpenseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Expense expense)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync(IsolationLevel.Serializable);
            try
            {
                var totalExpenseAmount = expense.ExpenseDetails.Sum(d => d.Amount);

                // Esta lectura queda "protegida" por la transacción
                var currentBalance = await
                    GetBalanceByMonetaryFundAsync(expense.Date.Month,
                        expense.ApplicationUserId, 
                        expense.MonetaryFundId);

                if (currentBalance < totalExpenseAmount)
                    throw new InvalidOperationException($"Insufficient balance. Available: ${currentBalance:N2}, Required: ${totalExpenseAmount:N2}");

                // Insertar los nuevos registros
                await CreateAsync(expense);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<Expense>> GetAllAsync(string userId)
        {
            var result = await _dbContext.Expenses
                .Where(expense => expense.ApplicationUserId == userId)
                .Include(expense => expense.ExpenseDetails)
                    .ThenInclude(details => details.ExpenseType)
                .Include(expense => expense.MonetaryFund)
                .AsNoTracking()
                .OrderBy(expense => expense.Date)
                .ToListAsync();

            return result;
        }

        public async Task<Expense?> GetAsync(Guid id, string userId)
        {
            return await _dbContext.Expenses
                .Where(expense => expense.ApplicationUserId == userId && expense.Id == id)
                .Include(expense => expense.ExpenseDetails)
                    .ThenInclude(details => details.ExpenseType)
                .Include(expense => expense.MonetaryFund)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Expense>> GetExpenseByDatesAsync(DateTime fromDate, DateTime toDate, string userId)
        {
            var result = await _dbContext.Expenses
                .Where(expense => expense.ApplicationUserId == userId
                    && expense.Date >= fromDate && expense.Date <= toDate)
                .Include(expense => expense.ExpenseDetails)
                    .ThenInclude(details => details.ExpenseType)
                .Include(expense => expense.MonetaryFund)
                .AsNoTracking()
                .OrderBy(expense => expense.Date)
                .ToListAsync();

            return result;
        }

        public async Task<double> GetExpensesAsync(int month, string userId)
        {
            return await _dbContext.Expenses
                .Where(expense => expense.ApplicationUserId == userId && expense.Date.Month == month)
                .SelectMany(expense => expense.ExpenseDetails)
                .SumAsync(detail => detail.Amount);
        }

        private async Task<double> GetBalanceByMonetaryFundAsync(int month, string userId, Guid id)
        {
            var response = await _dbContext.Deposit
            .Where(deposit => deposit.ApplicationUserId == userId
                && deposit.Date.Month == month 
                && deposit.MonetaryFundId == id)
            .SumAsync(deposit => deposit.Amount);

            return response;
        }
    }
}