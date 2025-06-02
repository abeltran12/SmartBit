using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using SmartBit.Models;
using SmartBit.Repositories;

namespace SmartBit.Services
{
    public class ExpendService : IExpendService
    {
        private readonly IExpenseRepository _repository;
        private readonly AuthenticationStateProvider _authProvider;
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public ExpendService(
            IExpenseRepository repository,
            AuthenticationStateProvider authProvider)
        {
            _repository = repository;
            _authProvider = authProvider;
        }

        public async Task CreateAsync(Expense expense)
        {
            try
            {
                if (expense.ExpenseDetails.Count == 0)
                    throw new InvalidOperationException("There must be payment details");

                var userId = await GetUserId();
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
            var userId = await GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            return await _repository.GetAllAsync(userId);
        }

        public async Task<Expense?> GetAsync(Guid id)
        {
            var userId = await GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var expense = await _repository.GetAsync(id, userId);
            return expense ?? throw new KeyNotFoundException("Object not found");
        }
        
        private async Task<string?> GetUserId()
        {
            try
            {
                var authState = await _authProvider.GetAuthenticationStateAsync();
                var user = authState.User;

                if (user.Identity?.IsAuthenticated != true)
                    return null;

                return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            catch
            {
                return null;
            }
        }
    }
}