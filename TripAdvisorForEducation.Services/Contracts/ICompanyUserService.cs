using System.Collections.Generic;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Services.Contracts
{
    public interface ICompanyUserService
    {
        List<CompanyUser> GetCompanyUsers();
        
        CompanyUser GetCompany(string id);

        List<Product> GetCompanyProducts(string id);
    }
}
