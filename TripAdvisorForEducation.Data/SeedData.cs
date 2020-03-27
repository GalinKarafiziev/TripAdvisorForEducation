using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<TripAdvisorForEducationDbContext>();

            SeedCompanyUsers(context);
            SeedProducts(context);
        }

        private static void SeedProducts(TripAdvisorForEducationDbContext context)
        {
            if (context.Product.Any())
                return;

            context.Product.AddRange(
                new Product
                {
                    UserId = "1",
                    Description = "Feedback tool",
                    Website = "https://drieam.com/",
                    Name = "FeedPulse",
                    Categories = new List<ProductCategory>(),
                    Reviews = new List<Review>()
                },
                new Product
                {
                    UserId = "1",
                    Description = "Feedback tool",
                    Website = "https://drieam.com/",
                    Name = "StudyCoach",
                    Categories = new List<ProductCategory>(),
                    Reviews = new List<Review>()
                });

            context.SaveChanges();
        }

        private static void SeedCompanyUsers(TripAdvisorForEducationDbContext context)
        {
            if (context.CompanyUser.Any())
                return;

            context.CompanyUser.AddRange(
                new CompanyUser
                {
                    UserName = "Drieam",
                    Description = "Startup company in Eindhoven",
                    Website = "https://drieam.com/",
                    Id = "1",
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
                    Id = "2",
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
                    Id = "3",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                }
            );

            context.SaveChanges();
        }
    }
}
