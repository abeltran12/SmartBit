using Microsoft.EntityFrameworkCore;
using SmartBit.Models;

namespace SmartBit.Data.Seeders
{
    public static class ExpenseTypesSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseType>().HasData(
                new ExpenseType
                {
                    Code = "0001",
                    Name = "Administrative Expenses",
                    Description = "Expenses related to the administration and management of the company",
                    Active = true
                },
                new ExpenseType
                {
                    Code = "0002",
                    Name = "Operational Expenses",
                    Description = "Expenses directly related to the business operations",
                    Active = true
                },
                new ExpenseType
                {
                    Code = "0003",
                    Name = "Marketing Expenses",
                    Description = "Expenses related to advertising, promotion, and marketing",
                    Active = true
                }
            );
        }
    }
}