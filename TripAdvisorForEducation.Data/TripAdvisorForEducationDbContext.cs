using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TripAdvisorForEducation.Data.Configurations;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Web.Models;

namespace TripAdvisorForEducation.Data
{
    public class TripAdvisorForEducationDbContext : ApiAuthorizationDbContext<ApplicationUser>, ITripAdvisorforEducationDbContext
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

        public DbSet<AcademicsUser> AcademicUsers { get; set; }

        public DbSet<CompanyUser> CompanyUsers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Review> Reviews { get; set; }

        DbSet<T> ITripAdvisorforEducationDbContext.Set<T>()
                where T : class
        {
            return base.Set<T>();
        }
    }
}
