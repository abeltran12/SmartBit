using SmartBit.Models;
using SmartBit.Repositories;

namespace SmartBit.Services
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IExpenseTypeRepository _repository;
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public ExpenseTypeService(IExpenseTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(ExpenseType expenseType)
        {
            await _semaphore.WaitAsync();
            try
            {
                var newCode = await _repository.GetLastCodeAsync();
                expenseType.Code = newCode;
                await _repository.CreateAsync(expenseType);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task DeleteAsync(string code)
        {
            await _repository.GetAsync(code);
            await _repository.DeleteAsync(code);
        }

        public async Task<List<ExpenseType>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result;
        }

        public async Task<ExpenseType?> GetAsync(string code)
        {
            var expenseType = await _repository.GetAsync(code);
            return expenseType ?? throw new KeyNotFoundException("Object not found");
        }

        public async Task UpdateAsync(ExpenseType expenseType)
        {
            await _repository.GetAsync(expenseType.Code);
            await _repository.UpdateAsync(expenseType);
        }
    }
}