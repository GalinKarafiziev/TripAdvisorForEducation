using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data
{
    public static class SeedData
    {
        public async static Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TripAdvisorForEducationDbContext>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            await SeedRolesAsync(roleManager);
            await SeedAdminUserAsync(userManager);
            await SeedCompanyUsersAsync(context);
            await SeedCategoriesAsync(context);
            await SeedProductsAsync(context);
        }

        private async static Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            foreach (var roleName in Enum.GetNames(typeof(UserRoles)))
                if (!await roleManager.RoleExistsAsync(roleName))
                    await roleManager.CreateAsync(new IdentityRole { Name = roleName });
        }

        private async static Task SeedAdminUserAsync(UserManager<IdentityUser> userManager)
        {
            await userManager.CreateAsync(new AcademicsUser()
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
            }, "TestAdminUser123$");

            var user = await userManager.FindByEmailAsync("admin@gmail.com");
            await userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
        }

        private async static Task SeedCompanyUsersAsync(TripAdvisorForEducationDbContext context)
        {
            if (await context.CompanyUsers.AnyAsync())
                return;

            await context.CompanyUsers.AddRangeAsync(
                new CompanyUser
                {
                    UserName = "Drieam",
                    Description = "Startup company in Eindhoven",
                    Website = "https://drieam.com/",
                    Id = "904860e9-ee59-41d5-8efb-4d480d11e526",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                },
                new CompanyUser
                {
                    UserName = "FeedbackFruits",
                    Description = "Startup company in Eindhoven",
                    Website = "https://drieam.com/",
                    Id = "efdd8cd1-1a97-493e-8119-e48320bd2940",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                },
                new CompanyUser
                {
                    UserName = "Canvas",
                    Description = "Startup company in Eindhoven",
                    Website = "https://drieam.com/",
                    Id = "9e3c4596-40ee-4b1c-8e26-1c697d740d77",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                });

            await context.SaveChangesAsync();
        }

        private async static Task SeedCategoriesAsync(TripAdvisorForEducationDbContext context)
        {
            if (await context.Categories.AnyAsync())
                return;

            await context.Categories.AddRangeAsync(
                new Category { CategoryName = "Assistance" },
                new Category { CategoryName = "Feedback tools" },
                new Category { CategoryName = "Communication" },
                new Category { CategoryName = "Task Management" },
                new Category { CategoryName = "Schedule" },
                new Category { CategoryName = "Presentation" },
                new Category { CategoryName = "Peer Feedback" },
                new Category { CategoryName = "Documentation" },
                new Category { CategoryName = "Interactive video" },
                new Category { CategoryName = "Grading" },
                new Category { CategoryName = "Peer Reviews" },
                new Category { CategoryName = "Plan Management" },
                new Category { CategoryName = "Learning Management System" });

            await context.SaveChangesAsync();
        }

        private async static Task SeedProductsAsync(TripAdvisorForEducationDbContext context)
        {
            if (await context.Products.AnyAsync())
                return;

            await context.Products.AddRangeAsync(
                new Product
                {
                    UserId = "904860e9-ee59-41d5-8efb-4d480d11e526",
                    Description = "Feedback tool",
                    Website = "https://drieam.com/",
                    Name = "FeedPulse",
                    Categories = new List<ProductCategory>(),
                    Reviews = new List<Review>()
                },
                new Product
                {
                    UserId = "904860e9-ee59-41d5-8efb-4d480d11e526",
                    Description = "Feedback tool",
                    Website = "https://drieam.com/",
                    Name = "StudyCoach",
                    Categories = new List<ProductCategory>(),
                    Reviews = new List<Review>()
                });

            await context.SaveChangesAsync();
        }
    }
}
