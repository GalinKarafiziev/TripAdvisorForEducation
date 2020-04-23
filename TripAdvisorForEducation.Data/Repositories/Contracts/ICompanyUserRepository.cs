using System.Collections.Generic;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data.Repositories.Contracts
{
    public interface ICompanyUserRepository : IRepository<CompanyUser>
    {
        Task<IEnumerable<Product>> GetCompanyProductsAsync(string companyId);
    }
}
