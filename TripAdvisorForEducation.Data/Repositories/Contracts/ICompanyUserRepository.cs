using System.Linq;
using TripAdvisorForEducation.Data.Contracts;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Data.Repositories.Contracts
{
    public interface ICompanyUserRepository : IRepository<CompanyUser>
    {
        IQueryable<Product> GetCompanyProducts(string companyId);
    }
}
