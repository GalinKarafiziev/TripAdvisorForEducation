using CuttingEdge.Conditions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) => 
            _categoryRepository = categoryRepository;

        public async Task<(bool success, string categoryId)> AddCategoryAsync(string categoryName)
        {
            try
            {
                Condition.Requires(categoryName).IsNotNull();
                Category category = new Category() { CategoryName = categoryName };
                    await _categoryRepository.AddAsync(category);
                    await _categoryRepository.SaveChangesAsync();
                    return (true, category.CategoryId);
                
            }
            catch(Exception ex)
            {
                return (false, null);
            }
            
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync() => 
            await _categoryRepository.AllAsync();

        public async Task<IEnumerable<Product>> GetCategoryProductsAsync(string categoryId)
        {
            try
            {
                return await _categoryRepository.GetCategoryProductsAsync(categoryId);
            }
            catch (Exception ex)
            {
                // TODO: Implement logging functionality (Logger) for this and the rest of the services.
                // TODO: Add try/catch in all services

                return Enumerable.Empty<Product>();
            }
        }
    }
}
