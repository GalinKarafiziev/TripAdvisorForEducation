using Microsoft.EntityFrameworkCore;
using System;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data
{
    public interface ITripAdvisorforEducationDbContext : IDisposable
    {
        DbSet<AcademicsUser> AcademicUser { get; set; }

        DbSet<CompanyUser> CompanyUser { get; set; }

        DbSet<Category> Category { get; set; }

        DbSet<Product> Product { get; set; }

        DbSet<Review> Review { get; set; }

        DbSet<ProductCategory> ProductsCategories { get; set; }

        DbContext DbContext { get; }
    }
}