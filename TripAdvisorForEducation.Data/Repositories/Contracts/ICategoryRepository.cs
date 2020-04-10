using System.Linq;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data.Repositories.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IQueryable<ProductCategory> GetCategoryProducts(string categoryId);
    }
}
