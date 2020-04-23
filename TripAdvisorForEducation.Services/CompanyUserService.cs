using System.Collections.Generic;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;
using TripAdvisorForEducation.Services.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class CompanyUserService : ICompanyUserService
    {
        private readonly ICompanyUserRepository _companyUserRepository;

        public CompanyUserService(ICompanyUserRepository companyUserRepository) => 
            _companyUserRepository = companyUserRepository;

        public async Task<IEnumerable<CompanyUser>> GetCompanyUsersAsync() => 
            await _companyUserRepository.AllAsync();

        public async Task<CompanyUser> GetCompanyAsync(string id) => 
            await _companyUserRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Product>> GetCompanyProductsAsync(string companyId) => 
            await _companyUserRepository.GetCompanyProductsAsync(companyId);
    }
}
