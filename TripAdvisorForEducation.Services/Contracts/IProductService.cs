using System.Collections.Generic;
using TripAdvisorForEducation.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace TripAdvisorForEducation.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product GetProduct(string productId);

        List<Review> GetProductReviews(string productId);

        CompanyUser GetProductCompany(string productId);

        List<ProductCategory> GetProductCategories(string productId);

        Product AddProduct(string description, string website, string name, string category, string user);
    }
}
