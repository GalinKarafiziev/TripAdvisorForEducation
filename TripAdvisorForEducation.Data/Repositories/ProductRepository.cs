using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Base;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(TripAdvisorForEducationDbContext context) 
            : base(context)
        {
        }

        public IQueryable<Review> GetProductReviews(int productId) => GetById(productId).Reviews.AsQueryable();
    }
}
