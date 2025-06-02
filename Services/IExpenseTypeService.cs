using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartBit.Models;

namespace SmartBit.Services
{
    public interface IExpenseTypeService
    {
        Task<ExpenseType?> GetAsync(string code);
        Task<List<ExpenseType>> GetAllAsync();
        Task CreateAsync(ExpenseType expenseType);
        Task UpdateAsync(ExpenseType expenseType);
        Task DeleteAsync(string code);
    }
}