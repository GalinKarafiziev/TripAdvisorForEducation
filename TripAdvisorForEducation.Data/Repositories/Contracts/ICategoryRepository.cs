using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data.Repositories.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Product>> GetCategoryProductsAsync(string categoryId);
    }
}
