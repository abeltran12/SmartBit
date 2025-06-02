using Microsoft.EntityFrameworkCore;

namespace SmartBit.Data.Seeders
{
    public static class ApplicationUserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
                {
                    Id = "08c77f09-af58-4fc7-87d6-d2648c7187cc",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin",
                    NormalizedEmail = "ADMIN",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEKv6cFHooCRU1s7UzzxW0bkACKmQAyJ3A25yILKJkY4rv2hpyiO+uSfx+p4ZMjkW4A==",
                    SecurityStamp = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890").ToString(),
                    ConcurrencyStamp = new Guid("12345678-90ab-cdef-1234-567890abcdef").ToString()
                }
            );
        }
    }
}