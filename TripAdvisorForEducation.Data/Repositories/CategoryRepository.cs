using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Base;
using TripAdvisorForEducation.Data.Repositories.Contracts;
using TripAdvisorForEducation.Data.Repositories.Extensions;

namespace TripAdvisorForEducation.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TripAdvisorForEducationDbContext context) 
            : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetCategoryProductsAsync(string categoryId)
        {
            var category = await GetByIdAsync(categoryId);
            await category.LoadEntityCollectionAsync(Context, x => x.Products);

            var loadedProductsReferences = category
                .Products
                .Select(async x => (await x.LoadEntityReferenceAsync(Context, x => x.Product)).Product);

            return await Task.WhenAll(loadedProductsReferences);
        }
    }
}
