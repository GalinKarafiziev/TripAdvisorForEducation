using AutoMapper;
using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;
using TripAdvisorForEducation.Data.ViewModels;

namespace TripAdvisorForEducation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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

        public (bool success, string productId) AddProduct(ProductViewModel productViewModel)
        {
            try
            {
                Condition.Requires(productViewModel.Name, nameof(productViewModel.Name)).IsNotNullOrEmpty();
                Condition.Requires(productViewModel.Description, nameof(productViewModel.Description)).IsNotNullOrEmpty();
                Condition.Requires(productViewModel.UserId, nameof(productViewModel.UserId)).IsNotNullOrEmpty();
                Condition.Requires(productViewModel.CategoryIds, nameof(productViewModel.CategoryIds)).IsNotEmpty();

                var product = _mapper.Map<Product>(productViewModel);
                _productRepository.Add(product);

                foreach (var categoryId in productViewModel.CategoryIds)
                {
                    if (product.Categories.Any(x => x.CategoryId == categoryId))
                        continue;

                    product.Categories.Add(new ProductCategory
                    {
                        ProductId = product.ProductId,
                        CategoryId = categoryId
                    });
                }

                _productRepository.SaveChanges();

                return (true, product.ProductId);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }

        public bool DeleteProduct(string productId)
        {
            try
            {
                Condition.Requires(productId, nameof(productId)).IsNotNullOrEmpty();
                
                _productRepository.Delete(productId);
                _productRepository.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
