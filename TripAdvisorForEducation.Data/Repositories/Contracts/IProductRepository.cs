using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripAdvisorForEducation.Data.Contracts;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data.Repositories.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Review> GetProductReviews(int productId);
    }
}
