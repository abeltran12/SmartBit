using Microsoft.EntityFrameworkCore;
using SmartBit.Models;

namespace SmartBit.Data.Seeders
{
    public static class DepositSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deposit>().HasData(

                new Deposit
                {
                    Id = new Guid("a1111111-1111-1111-1111-111111111111"),
                    Date = new DateTime(2024, 1, 15),
                    Amount = 1500.50,
                    MonetaryFundId = new Guid("0e09e00a-ca41-4d01-89ba-f084231c2fe7"),
                    ApplicationUserId = "08c77f09-af58-4fc7-87d6-d2648c7187cc"
                },
                new Deposit
                {
                    Id = new Guid("a2222222-2222-2222-2222-222222222222"),
                    Date = new DateTime(2024, 2, 10),
                    Amount = 750.25,
                    MonetaryFundId = new Guid("0e09e00a-ca41-4d01-89ba-f084231c2fe7"),
                    ApplicationUserId = "08c77f09-af58-4fc7-87d6-d2648c7187cc"
                },

                new Deposit
                {
                    Id = new Guid("b3333333-3333-3333-3333-333333333333"),
                    Date = new DateTime(2024, 1, 20),
                    Amount = 2000.00,
                    MonetaryFundId = new Guid("bd6e1302-4fa1-41ea-a91c-260ea6c2278d"),
                    ApplicationUserId = "08c77f09-af58-4fc7-87d6-d2648c7187cc"
                },
                new Deposit
                {
                    Id = new Guid("b4444444-4444-4444-4444-444444444444"),
                    Date = new DateTime(2024, 3, 5),
                    Amount = 1200.75,
                    MonetaryFundId = new Guid("bd6e1302-4fa1-41ea-a91c-260ea6c2278d"),
                    ApplicationUserId = "08c77f09-af58-4fc7-87d6-d2648c7187cc"
                },

                new Deposit
                {
                    Id = new Guid("c5555555-5555-5555-5555-555555555555"),
                    Date = new DateTime(2024, 2, 15),
                    Amount = 500.00,
                    MonetaryFundId = new Guid("6ca2098b-1126-4515-8ca2-fb503321620d"),
                    ApplicationUserId = "08c77f09-af58-4fc7-87d6-d2648c7187cc"
                },
                new Deposit
                {
                    Id = new Guid("c6666666-6666-6666-6666-666666666666"),
                    Date = new DateTime(2024, 3, 20),
                    Amount = 850.30,
                    MonetaryFundId = new Guid("6ca2098b-1126-4515-8ca2-fb503321620d"),
                    ApplicationUserId = "08c77f09-af58-4fc7-87d6-d2648c7187cc"
                }
            );
        }
    }
}