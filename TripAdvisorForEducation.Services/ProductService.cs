using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TripAdvisorForEducation.Data;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class ProductService : IProductService
    {
        
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICompanyUserRepository _companyUserRepository;
        

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, ICompanyUserRepository companyUserRepository)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._companyUserRepository = companyUserRepository;
            
            
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

        public CompanyUser GetProductCompany(string productId) => _productRepository.GetProductCompany(productId);

        public List<ProductCategory> GetProductCategories(string productId) 
            => _productRepository.GetProductCategories(productId).ToList();



        public Product AddProduct(string description, string website, string name, string category, string user)
        {

            Product product = new Product()
            {
                ProductId = "TEST_9_POMOSHT",
                Description = description,
                Website = website,
                Name = name,
            };

            Category _category = _categoryRepository.All().Where(x => x.CategoryId == category).FirstOrDefault();
            CompanyUser _user = _companyUserRepository.All().Where(x => x.Id == user).FirstOrDefault();

            product.User = _user;
            product.UserId = _user.Id;
            _user.Products.Add(product);

            ProductCategory productCategory = new ProductCategory()
                {
                    Category = _category,
                    CategoryId = _category.CategoryId,
                    Product = product,
                    ProductId = product.ProductId
                };

            product.Categories.Add(productCategory);
            _category.Products.Add(productCategory);
            _productRepository.Add(product);
            
            return product;

        }
    }
}
