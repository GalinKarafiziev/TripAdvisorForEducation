using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TripAdvisorForEducation.Data.Configurations;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data
{
    public class TripAdvisorForEducationDbContext : ApiAuthorizationDbContext<IdentityUser>, ITripAdvisorforEducationDbContext
    {
        public TripAdvisorForEducationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductCategoryConfiguration());
        }

        public DbContext DbContext => this;

        public DbSet<AcademicsUser> AcademicUsers { get; set; }

        public DbSet<CompanyUser> CompanyUsers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<ProductCategory> ProductsCategories { get; set; }

        public DbSet<PendingCompany> PendingCompanies { get; set; }
    }
}
