using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartBit.Models;

namespace SmartBit.Repositories
{
    public interface IMonetaryFundRepository
    {
        Task<MonetaryFund?> GetAsync(Guid id);
        Task<List<MonetaryFund>> GetAllAsync();
        Task CreateAsync(MonetaryFund monetaryFund);
        Task UpdateAsync(MonetaryFund monetaryFund);
        Task DeleteAsync(Guid id);
    }
}