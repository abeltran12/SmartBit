using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using SmartBit.Models;
using SmartBit.Repositories;

namespace SmartBit.Services
{
    public class DepositService : IDepositService
    {
        private readonly IDepositRepository _repository;
        private readonly AuthenticationStateProvider _authProvider;

        public DepositService(
            IDepositRepository repository,
            AuthenticationStateProvider authProvider)
        {
            _repository = repository;
            _authProvider = authProvider;
        }

        public async Task CreateAsync(Deposit deposit)
        {
            var userId = await GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            deposit.ApplicationUserId = userId;
            await _repository.CreateAsync(deposit);
        }

        public async Task<List<Deposit>> GetAllAsync()
        {
            var userId = await GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var result = await _repository.GetAllAsync(userId);
            return result;
        }

        public async Task<Deposit?> GetAsync(Guid id)
        {
            var userId = await GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var expenseType = await _repository.GetAsync(id, userId);
            return expenseType ?? throw new KeyNotFoundException("Object not found");
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