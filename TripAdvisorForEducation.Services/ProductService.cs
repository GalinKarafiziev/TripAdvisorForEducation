using System.Collections.Generic;
using System.Linq;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(string productId) => _productRepository.GetById(productId);

        public List<Product> GetProducts() => _productRepository.All().ToList();

        public List<Review> GetProductReviews(string productId)
        {
            var result = _productRepository.GetProductReviews(productId).ToList();

            if (result == null)
                return new List<Review>();

            return result;
        }

        public CompanyUser GetProductCompany(string productId) => 
            _productRepository.GetProductCompany(productId);

        public List<Category> GetProductCategories(string productId) => 
            _productRepository.GetProductCategories(productId).ToList();

        public Product AddProduct(string description, string website, string name, string categoryId, string userId)
        {
            var product = new Product
            {
                Description = description,
                Website = website,
                Name = name,
                UserId = userId
            };

            _productRepository.Add(product);
            product.Categories.Add(new ProductCategory
            {
                ProductId = product.ProductId,
                CategoryId = categoryId
            });

            _productRepository.SaveChanges();

            return product;
        }
    }
}
