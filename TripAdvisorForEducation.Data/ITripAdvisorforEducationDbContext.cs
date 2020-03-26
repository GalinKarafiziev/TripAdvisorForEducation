using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        DbContext DbContext { get; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        DbSet<T> Set<T>()
            where T : class;
    }
}