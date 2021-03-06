﻿using Microsoft.Extensions.DependencyInjection;
using TripAdvisorForEducation.Services.Contracts;

namespace TripAdvisorForEducation.Services
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IAcademicsUserService, AcademicsUserService>();
            services.AddScoped<ICompanyUserService, CompanyUserService>();
        }
    }
}
