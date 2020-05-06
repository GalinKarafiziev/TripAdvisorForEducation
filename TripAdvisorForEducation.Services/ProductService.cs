using AutoMapper;
using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Product> GetProductAsync(string productId) =>
            await _productRepository.GetByIdAsync(productId);

        public async Task<IEnumerable<Product>> GetProductsAsync() =>
            await _productRepository.AllAsync();

        public async Task<IEnumerable<Review>> GetProductReviewsAsync(string productId)
        {
            var result = await _productRepository.GetProductReviewsAsync(productId);

            if (result == null)
                return Enumerable.Empty<Review>();

            return result;
        }

        public async Task<CompanyUser> GetProductCompanyAsync(string productId) =>
            await _productRepository.GetProductCompanyAsync(productId);

        public async Task<IEnumerable<Category>> GetProductCategoriesAsync(string productId) =>
            await _productRepository.GetProductCategoriesAsync(productId);

        public async Task<(bool success, string productId)> AddProductAsync(ProductViewModel productViewModel)
        {
            try
            {
                Condition.Requires(productViewModel.Name, nameof(productViewModel.Name)).IsNotNullOrEmpty();
                Condition.Requires(productViewModel.Description, nameof(productViewModel.Description)).IsNotNullOrEmpty();
                Condition.Requires(productViewModel.UserId, nameof(productViewModel.UserId)).IsNotNullOrEmpty();
                Condition.Requires(productViewModel.CategoryIds, nameof(productViewModel.CategoryIds)).IsNotEmpty();

                var product = _mapper.Map<Product>(productViewModel);
                await _productRepository.AddAsync(product);

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

                await _productRepository.SaveChangesAsync();

                return (true, product.ProductId);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }

        public async Task<bool> DeleteProductAsync(string productId)
        {
            try
            {
                Condition.Requires(productId, nameof(productId)).IsNotNullOrEmpty();

                await _productRepository.DeleteAsync(productId);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProductAsync(ProductViewModel productViewModel, string productId)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(productId);
                _mapper.Map(productViewModel, product);
                await _productRepository.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
