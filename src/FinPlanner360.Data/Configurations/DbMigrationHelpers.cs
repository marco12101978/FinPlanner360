using FinPlanner360.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinPlanner360.Data.Configurations
{
    public static class DbMigrationHelperExtension
    {
        public static void UseDbMigrationHelper(this WebApplication app)
        {
            DbMigrationHelpers.EnsureSeedData(app).Wait();
        }
    }

    public static class DbMigrationHelpers
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<MeuDbContext>();
            var contextId = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();


            if (env.IsDevelopment())
            {
                await context.Database.MigrateAsync();
                await contextId.Database.MigrateAsync();

                await EnsureSeedProducts(serviceProvider, context, contextId);
            }
        }

        private static async Task EnsureSeedProducts(IServiceProvider serviceProvider, MeuDbContext context, ApplicationDbContext contextId)
        {
            if (contextId.Users.Any())
                return;


            #region Usuario Identity

            var idAutor = Guid.NewGuid();

            var user = new Microsoft.AspNetCore.Identity.IdentityUser
            {
                Id = idAutor.ToString(),
                UserName = "marco@imperiumsolucoes.com.br",
                NormalizedUserName = "MARCO@IMPERIUMSOLUCOES.COM.BR",
                Email = "marco@imperiumsolucoes.com.br",
                NormalizedEmail = "MARCO@IMPERIUMSOLUCOES.COM.BR",
                AccessFailedCount = 0,
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEK2wx+k3kW2104aBWullMN7JJ6VTreIIcBpiyzNVRhRONj2J5GX9ig8EIA9TQcqn9w==",
                TwoFactorEnabled = false,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            await contextId.Users.AddAsync(user);

            await contextId.SaveChangesAsync();

            #endregion

            #region Roles

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();


            string[] roleNames = { "Admin", "User", "Manager" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var _userManager = serviceProvider.GetService<UserManager<Microsoft.AspNetCore.Identity.IdentityUser>>();
            user = await _userManager.FindByIdAsync(idAutor.ToString());

            await _userManager.AddToRoleAsync(user, "Admin");


            #endregion


        }
    }
}
