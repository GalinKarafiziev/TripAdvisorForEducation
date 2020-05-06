using Microsoft.EntityFrameworkCore;
using System;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data
{
    public interface ITripAdvisorforEducationDbContext : IDisposable
    {
        DbSet<AcademicsUser> AcademicUsers { get; set; }

        DbSet<CompanyUser> CompanyUsers { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Review> Reviews { get; set; }

        DbSet<ProductCategory> ProductsCategories { get; set; }
        
        DbSet<PendingCompany> PendingCompanies { get; set; }

        DbContext DbContext { get; }
    }
}