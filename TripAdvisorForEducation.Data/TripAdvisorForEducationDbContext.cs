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
            builder.ApplyConfiguration(new ProductCategoryConfiguration());

            base.OnModelCreating(builder);
        }

        public DbContext DbContext => this;

        public DbSet<AcademicsUser> AcademicUser { get; set; }

        public DbSet<CompanyUser> CompanyUser { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Review> Review { get; set; }
    }
}
