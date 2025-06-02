using Microsoft.EntityFrameworkCore;
using SmartBit.Models;

namespace SmartBit.Data.Seeders
{
    public static class ExpenseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>().HasData(
                new Expense
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Date = new DateTime(2025, 5, 26),
                    BusinessName = "Papelería San José",
                    DocumentType = DocumentType.Invoice,
                    Observations = "Office supplies and stationery",
                    MonetaryFundId = new Guid("BD6E1302-4FA1-41EA-A91C-260EA6C2278D"),
                    ApplicationUserId = "08c77f09-af58-4fc7-87d6-d2648c7187cc"
                },
                new Expense
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    Date = new DateTime(2025, 5, 20),
                    BusinessName = "Restaurante El Buen Sabor",
                    DocumentType = DocumentType.Other,
                    Observations = "Business lunch with client",
                    MonetaryFundId = new Guid("6CA2098B-1126-4515-8CA2-FB503321620D"),
                    ApplicationUserId = "08c77f09-af58-4fc7-87d6-d2648c7187cc"
                }
            );
        }
    }
}