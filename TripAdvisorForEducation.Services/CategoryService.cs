using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public List<Category> GetCategories() => _categoryRepository.All().ToList();

        public List<ProductCategory> GetCategoryProducts(string categoryId)
            => _categoryRepository.GetCategoryProducts(categoryId).ToList();
    }
}
