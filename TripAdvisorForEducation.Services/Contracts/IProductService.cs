using System.Collections.Generic;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.ViewModels;

namespace TripAdvisorForEducation.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(string productId);

        Task<IEnumerable<Review>> GetProductReviewsAsync(string productId);

        Task<CompanyUser> GetProductCompanyAsync(string productId);

        Task<IEnumerable<Category>> GetProductCategoriesAsync(string productId);

        Task<(bool success, string productId)> AddProductAsync(ProductViewModel productViewModel);

        Task<bool> DeleteProductAsync(string productId);

        Task<bool> UpdateProductAsync(ProductViewModel productViewModel, string productId);
    }
}
