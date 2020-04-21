using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TripAdvisorForEducation.Web.Data;

[assembly: HostingStartup(typeof(TripAdvisorForEducation.Web.Areas.Identity.IdentityHostingStartup))]
namespace TripAdvisorForEducation.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TripAdvisorForEducationWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TripAdvisorForEducationWebContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TripAdvisorForEducationWebContext>();
            });
        }
    }
}