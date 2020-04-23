using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Base;
using TripAdvisorForEducation.Data.Repositories.Contracts;
using TripAdvisorForEducation.Data.Repositories.Extensions;

namespace TripAdvisorForEducation.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(TripAdvisorForEducationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetProductCategoriesAsync(string productId)
        {
            var product = await GetByIdAsync(productId);
            await product.LoadEntityCollectionAsync(Context, x => x.Categories);

            var loadedCategoriesReferences = product
                .Categories
                .Select(async x => (await x.LoadEntityReferenceAsync(Context, x => x.Category)).Category);

            return await Task.WhenAll(loadedCategoriesReferences);
        }

        public async Task<CompanyUser> GetProductCompanyAsync(string productId)
        {
            var product = await GetByIdAsync(productId);
            await product.LoadEntityReferenceAsync(Context, x => x.User);

            return product.User;
        }

        public async Task<IEnumerable<Review>> GetProductReviewsAsync(string productId)
        {
            var product = await GetByIdAsync(productId);
            await product.LoadEntityCollectionAsync(Context, x => x.Reviews);

            return product.Reviews;
        }
    }
}
