using System.Collections.Generic;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data.Repositories.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Review>> GetProductReviewsAsync(string productId);

        Task<IEnumerable<Category>> GetProductCategoriesAsync(string productId);

        Task<CompanyUser> GetProductCompanyAsync(string productId);
    }
}
