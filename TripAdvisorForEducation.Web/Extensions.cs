using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TripAdvisorForEducation.Data;

namespace TripAdvisorForEducation.Web
{
    public static class Extensions
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<TripAdvisorForEducationDbContext>();

            context.Database.EnsureCreated();
            context.Database.Migrate();
            SeedData.Initialize(serviceScope.ServiceProvider);
        }
    }
}
