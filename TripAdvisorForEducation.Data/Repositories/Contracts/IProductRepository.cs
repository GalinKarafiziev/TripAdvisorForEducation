using System.Linq;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data.Repositories.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Review> GetProductReviews(string productId);

        IQueryable<Category> GetProductCategories(string productId);

        CompanyUser GetProductCompany(string productId);
    }
}
