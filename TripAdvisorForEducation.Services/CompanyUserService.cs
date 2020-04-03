using System.Collections.Generic;
using System.Linq;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;
using TripAdvisorForEducation.Services.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class CompanyUserService : ICompanyUserService
    {
        private readonly ICompanyUserRepository _companyUserRepository;

        public CompanyUserService(ICompanyUserRepository companyUserRepository)
        {
            this._companyUserRepository = companyUserRepository;
        }

        public CompanyUser GetCompany(string id) => _companyUserRepository.GetById(id);

        public List<Product> GetCompanyProducts(string companyId) 
            => _companyUserRepository.GetCompanyProducts(companyId).ToList();
    }
}
