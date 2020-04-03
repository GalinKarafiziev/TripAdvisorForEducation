using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Base;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TripAdvisorForEducationDbContext context) 
            : base(context)
        {
        }

        public IQueryable<ProductCategory> GetCategoryProducts(string categoryId)
        {
            var category = GetById(categoryId);

            Context
                .Entry(category)
                .Collection(x => x.Products)
                .Load();

            return category.Products.AsQueryable();
        }
    }
}
