using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data;

namespace TripAdvisorForEducation.Web.Utilities
{
    public static class Extensions
    {
        public async static Task UpdateDatabaseAsync(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<TripAdvisorForEducationDbContext>();

            //await context.Database.EnsureCreatedAsync();
            //await context.Database.MigrateAsync();
            await SeedData.InitializeAsync(serviceScope.ServiceProvider);
        }
    }
}
