using System.Linq;
using TripAdvisorForEducation.Data.Contracts;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data.Repositories.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Review> GetProductReviews(string productId);

        IQueryable<ProductCategory> GetProductCategories(string productId);

        CompanyUser GetProductCompany(string productId);
    }
}
