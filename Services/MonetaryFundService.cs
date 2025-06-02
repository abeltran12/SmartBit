using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using SmartBit.Models;
using SmartBit.Repositories;

namespace SmartBit.Services
{
    public class MonetaryFundService : IMonetaryFundService
    {
        private readonly IMonetaryFundRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MonetaryFundService(
            IMonetaryFundRepository repository,
            IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateAsync(MonetaryFund monetaryFund)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            monetaryFund.ApplicationUserId = userId!;
            await _repository.CreateAsync(monetaryFund);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.GetAsync(id);
            await _repository.DeleteAsync(id);
        }

        public async Task<List<MonetaryFund>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result;
        }

        public async Task<MonetaryFund?> GetAsync(Guid id)
        {
            var expenseType = await _repository.GetAsync(id);
            return expenseType ?? throw new KeyNotFoundException("Object not found");
        }

        public async Task UpdateAsync(MonetaryFund monetaryFund)
        {
            await _repository.GetAsync(monetaryFund.Id);
            await _repository.UpdateAsync(monetaryFund);
        }
    }
}