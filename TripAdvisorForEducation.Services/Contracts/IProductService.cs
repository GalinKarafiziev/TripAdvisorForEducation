using System.Collections.Generic;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.ViewModels;

namespace TripAdvisorForEducation.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product GetProduct(string productId);

        List<Review> GetProductReviews(string productId);

        CompanyUser GetProductCompany(string productId);

        List<Category> GetProductCategories(string productId);

        (bool success, string productId) AddProduct(ProductViewModel productViewModel);

        bool DeleteProduct(string productId);
    }
}
