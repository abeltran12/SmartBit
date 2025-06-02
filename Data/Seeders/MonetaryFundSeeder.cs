using Microsoft.EntityFrameworkCore;
using SmartBit.Models;

namespace SmartBit.Data.Seeders
{
    public static class MonetaryFundSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonetaryFund>().HasData(
                new MonetaryFund
                {
                    Id = new Guid("0e09e00a-ca41-4d01-89ba-f084231c2fe7"),
                    Name = "Cash",
                    Type = TypeMonetaryFund.Cash,
                    ApplicationUserId = "08c77f09-af58-4fc7-87d6-d2648c7187cc",
                    Active = true
                },
                new MonetaryFund
                {
                    Id = new Guid("bd6e1302-4fa1-41ea-a91c-260ea6c2278d"),
                    Name = "Bank of Ameryca",
                    Type = TypeMonetaryFund.SavingsAccount,
                    ApplicationUserId = "08c77f09-af58-4fc7-87d6-d2648c7187cc",
                    Active = true
                },
                new MonetaryFund
                {
                    Id = new Guid("6ca2098b-1126-4515-8ca2-fb503321620d"),
                    Name = "Western Union",
                    Type = TypeMonetaryFund.CheckingAccount,
                    ApplicationUserId = "08c77f09-af58-4fc7-87d6-d2648c7187cc",
                    Active = true
                }
            );
        }
    }
}