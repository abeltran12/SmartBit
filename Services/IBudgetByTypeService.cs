using SmartBit.Dtos;

namespace SmartBit.Services
{
    public interface IBudgetByTypeService
    {
        Task<(double budget, double expense)> LoadMonthData(int month);

        Task<List<MovementQueryDTO>> LoadExpensesAndBudgetByDatesAsync
            (DateTime fromDate, DateTime toDate);
            
        Task<List<ChartResponse>>LoadExpensesAndBudgetByDatesByMonetaryFundAsync
            (DateTime fromDate, DateTime toDate);
    }
}