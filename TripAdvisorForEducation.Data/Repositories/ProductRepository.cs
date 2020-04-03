using System.Linq;
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

        public IQueryable<ProductCategory> GetProductCategories(string productId) => 
            GetById(productId).GetCategories(Context).Categories.AsQueryable();

        public CompanyUser GetProductCompany(string productId)
        {
            var product = GetById(productId);

            Context
                .Entry(product)
                .Reference(x => x.User)
                .Load();

            return product.User;
        }

        public IQueryable<Review> GetProductReviews(string productId)
        {
            var product = GetById(productId);

            Context
                .Entry(product)
                .Collection(x => x.Reviews)
                .Load();

            return product.Reviews.AsQueryable();
        }
    }
}
