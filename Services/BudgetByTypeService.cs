using System.Security.Claims;
using SmartBit.Dtos;
using SmartBit.Models;
using SmartBit.Repositories;

namespace SmartBit.Services
{
    public class BudgetByTypeService : IBudgetByTypeService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDepositRepository _depositRepository;
        private readonly IExpenseRepository _expenseRepository;

        public BudgetByTypeService(
            IHttpContextAccessor httpContextAccessor,
            IDepositRepository depositRepository,
            IExpenseRepository expenseRepository
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _depositRepository = depositRepository;
            _expenseRepository = expenseRepository;
        }

        public async Task<List<MovementQueryDTO>> LoadExpensesAndBudgetByDatesAsync
            (DateTime fromDate, DateTime toDate)
        {
            string? userId = GetUserId();

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
            string? userId = GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            var budget = await _depositRepository.GetBalanceAsync(month, userId!);
            var expense = await _expenseRepository.GetExpensesAsync(month, userId!);

            return (budget, expense);
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