using System.Security.Claims;
using SmartBit.Models;
using SmartBit.Repositories;

namespace SmartBit.Services
{
    public class DepositService : IDepositService
    {
        private readonly IDepositRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepositService(
            IDepositRepository repository,
            IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateAsync(Deposit deposit)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            deposit.ApplicationUserId = userId;
            await _repository.CreateAsync(deposit);
        }

        public async Task<List<Deposit>> GetAllAsync()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var result = await _repository.GetAllAsync(userId);
            return result;
        }

        public async Task<Deposit?> GetAsync(Guid id)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var expenseType = await _repository.GetAsync(id, userId);
            return expenseType ?? throw new KeyNotFoundException("Object not found");
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