using System.Collections.Generic;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Services.Contracts
{
    public interface ICompanyUserService
    {
        Task<IEnumerable<CompanyUser>> GetCompanyUsersAsync();
        
        Task<CompanyUser> GetCompanyAsync(string id);

        Task<IEnumerable<Product>> GetCompanyProductsAsync(string id);
    }
}
