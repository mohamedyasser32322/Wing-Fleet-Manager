using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Helpers;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Data
{
    public static class SeedData
    {
        public static async Task EnsureSeedDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<WingDbContext>();

            if (!context.Roles.Any())
            {
                var adminRole = new Role
                {
                    Name = "admin",
                    IsAdmin = true,
                };

                var userRole = new Role
                {
                    Name = "user",
                    IsAdmin = false,
                };

                context.Roles.AddRange(adminRole,userRole);
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var adminRole = await context.Roles.FirstAsync(r=>r.Name == "admin");
                var adminUser = new User
                {
                    FullName = "System Admin",
                    Email = "admin@wing.sa",
                    HashPassword = PasswordHelper.PasswordHasher("Admin@12345"),
                    RoleId = adminRole.Id,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                };

                context.Users.Add(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }
}
