using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartBit.Data.Seeders;
using SmartBit.Models;

namespace SmartBit.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Deposit>()
            .HasOne(d => d.MonetaryFund)
            .WithMany()
            .HasForeignKey(d => d.MonetaryFundId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Expense>()
            .HasOne(d => d.MonetaryFund)
            .WithMany()
            .HasForeignKey(d => d.MonetaryFundId)
            .OnDelete(DeleteBehavior.Restrict);

        ApplicationUserSeeder.Seed(builder);
        MonetaryFundSeeder.Seed(builder);
        DepositSeeder.Seed(builder);
        ExpenseTypesSeeder.Seed(builder);
        ExpenseSeeder.Seed(builder);
        ExpenseDetailSeeder.Seed(builder);
    }

    public DbSet<ExpenseType> ExpenseTypes { get; set; }

    public DbSet<MonetaryFund> MonetaryFund { get; set; }

    public DbSet<Deposit> Deposit { get; set; }

    public DbSet<Expense> Expenses { get; set; }

    public DbSet<ExpenseDetail> ExpenseDetails { get; set; }
}

