using Microsoft.EntityFrameworkCore;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data.Repositories.Extensions
{
    public static class ProductExtensions
    {
        public static Product GetCategories(this Product product, DbContext context)
        {
            context
                .Entry(product)
                .Collection(x => x.Categories)
                .Load();

            return product;
        }
    }
}
