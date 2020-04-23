using System.Collections.Generic;
using System.Linq;
using TripAdvisorForEducation.Data;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            
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

        public Product UpdateProduct(string description, string website, string name, string categoryId, string productID)
        {
            Product product = _productRepository.GetById(productID);
            Category category = _categoryRepository.GetById(categoryId);
            if(description != null)
            {
                product.Description = description;
            }
            if(website != null)
            {
                product.Website = website;
            }
            if(name != null)
            {
                product.Name = name;
            }
            if(categoryId != null)
            {
                ProductCategory productCategory = new ProductCategory()
                {
                    Product = product,
                    ProductId = product.ProductId,
                    Category = category,
                    CategoryId = category.CategoryId,
                };

                product.Categories.Add(productCategory);
                category.Products.Add(productCategory);
            }

            _productRepository.Update(product);

            _productRepository.SaveChanges();

            return product;
           

            
        }

        public bool DeleteProduct(string productID)
        {
            Product product = _productRepository.GetById(productID);
            _productRepository.Delete(product);

            _productRepository.SaveChanges();
            return true;
        }
    }
}
