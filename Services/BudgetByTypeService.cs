using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using SmartBit.Dtos;
using SmartBit.Repositories;

namespace SmartBit.Services
{
    public class BudgetByTypeService : IBudgetByTypeService
    {
        private readonly AuthenticationStateProvider _authProvider;
        private readonly IDepositRepository _depositRepository;
        private readonly IExpenseRepository _expenseRepository;

        public BudgetByTypeService(
            AuthenticationStateProvider authProvider,
            IDepositRepository depositRepository,
            IExpenseRepository expenseRepository
            )
        {
            _authProvider = authProvider;
            _depositRepository = depositRepository;
            _expenseRepository = expenseRepository;
        }

        public async Task<List<MovementQueryDTO>> LoadExpensesAndBudgetByDatesAsync
            (DateTime fromDate, DateTime toDate)
        {
            string? userId = await GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var deposits = await _depositRepository.GetBalanceByDatesAsync
                (fromDate, toDate, userId);

            var mappedDeposits = deposits.Select(deposit => new MovementQueryDTO
            {
                Date = deposit.Date,
                Amount = deposit.Amount,
                MonetaryFundName = deposit.MonetaryFund?.Name ?? deposit.MonetaryFundName ?? string.Empty
            }).ToList();

            var expenses = await _expenseRepository.GetExpenseByDatesAsync
                (fromDate, toDate, userId);

            var mappedExpenses = expenses.Select(expense => new MovementQueryDTO
            {

                Date = expense.Date,
                Amount = expense.TotalAmount,
                MonetaryFundName = expense.MonetaryFund.Name,
                BusinessName = expense.BusinessName,
                DocumentType = expense.DocumentType,
                Observations = expense.Observations,
                Expense = true,

                // Mapeo de ExpenseDetails a ExpenseDetailsDTO
                ExpenseDetails = expense.ExpenseDetails?.Select(detail => new ExpenseDetailsDTO
                {
                    Amount = detail.Amount,
                    ExpenseTypeName = detail.ExpenseType?.Name ?? string.Empty
                }).ToList() ?? new List<ExpenseDetailsDTO>()

            }).ToList();

            return mappedDeposits.Concat(mappedExpenses).OrderBy(x => x.Date).ToList();
        }

        public async Task<(double budget, double expense)> LoadMonthData(int month)
        {
            string? userId = await GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var budget = await _depositRepository.GetBalanceAsync(month, userId!);
            var expense = await _expenseRepository.GetExpensesAsync(month, userId!);

            return (budget, expense);
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

        public async Task<List<ChartResponse>> LoadExpensesAndBudgetByDatesByMonetaryFundAsync(DateTime fromDate, DateTime toDate)
        {
            // Llamar al método existente
            var movements = await LoadExpensesAndBudgetByDatesAsync(fromDate, toDate);
            
            // Agrupar por MonetaryFundName y crear ChartResponse
            var chartResponse = movements
                .GroupBy(m => m.MonetaryFundName)
                    .Select(g => new ChartResponse
                    {
                        MonetaryFundName = g.Key,
                        DepositAmount = g.Where(m => !m.Expense).Sum(m => m.Amount),
                        ExpensesAmount = g.Where(m => m.Expense).Sum(m => m.Amount)
                    })
                .OrderBy(cr => cr.MonetaryFundName)
                .ToList();
            
            return chartResponse;
        }
    }
}