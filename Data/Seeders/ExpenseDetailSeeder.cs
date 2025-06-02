using Microsoft.EntityFrameworkCore;
using SmartBit.Models;

namespace SmartBit.Data.Seeders
{
    public static class ExpenseDetailSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseDetail>().HasData(
                new ExpenseDetail
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Amount = 75.00,
                    ExpenseId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    ExpenseTypeId = "0001"
                },
                new ExpenseDetail
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Amount = 125.50,
                    ExpenseId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    ExpenseTypeId = "0002"
                },
  
                new ExpenseDetail
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    Amount = 85.75,
                    ExpenseId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    ExpenseTypeId = "0002"
                },
                new ExpenseDetail
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Amount = 15.25,
                    ExpenseId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    ExpenseTypeId = "0003"
                }
            );
        }
    }
}