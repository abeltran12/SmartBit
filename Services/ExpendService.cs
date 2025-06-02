using System.Security.Claims;
using SmartBit.Models;
using SmartBit.Repositories;

namespace SmartBit.Services
{
    public class ExpendService : IExpendService
    {
        private readonly IExpenseRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public ExpendService(
            IExpenseRepository repository,
            IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateAsync(Expense expense)
        {
            try
            {
                if (expense.ExpenseDetails.Count == 0)
                    throw new InvalidOperationException("There must be payment details");

                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    throw new UnauthorizedAccessException("User not authenticated");
                }

                expense.ApplicationUserId = userId;

                await _repository.CreateAsync(expense);
            }
            finally
            {
                
            }
        }

        public async Task<List<Expense>> GetAllAsync()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            return await _repository.GetAllAsync(userId);
        }

        public async Task<Expense?> GetAsync(Guid id)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var expense = await _repository.GetAsync(id, userId);
            return expense ?? throw new KeyNotFoundException("Object not found");
        }
        
        private string? GetUserId()
        {
            try
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext?.User?.Identity?.IsAuthenticated != true)
                {
                    return null;
                }

                var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return userId;
            }
            catch
            {
                return null;
            }
        }
    }
}