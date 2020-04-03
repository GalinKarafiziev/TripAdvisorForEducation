using System.Collections.Generic;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product GetProduct(string productId);

        List<Review> GetProductReviews(string productId);

        CompanyUser GetProductCompany(string productId);

        List<ProductCategory> GetProductCategories(string productId);
    }
}
