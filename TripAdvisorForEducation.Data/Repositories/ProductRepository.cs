using System.Collections.Generic;
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
            GetById(productId).LoadEntityCollection(Context, x => x.Categories).Categories.AsQueryable();

        public CompanyUser GetProductCompany(string productId) => 
            GetById(productId).LoadEntityReference(Context, x => x.User).User;

        public IQueryable<Review> GetProductReviews(string productId) => 
            GetById(productId).LoadEntityCollection(Context, x => x.Reviews).Reviews.AsQueryable();


    }
}
