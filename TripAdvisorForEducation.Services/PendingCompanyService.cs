using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;
using TripAdvisorForEducation.Services.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class PendingCompanyService : IPendingCompanyService
    {
        private readonly IPendingCompanyRepository _pendingCompanyRepository;

        public PendingCompanyService(IPendingCompanyRepository pendingCompanyRepository)
        {
            _pendingCompanyRepository = pendingCompanyRepository;
        }

        public async Task<bool> AddPendingCompanyAsync(PendingCompany newCompany)
        {
            try
            {
                Condition.Requires(newCompany.CompanyName, nameof(newCompany.CompanyName)).IsNotNullOrEmpty();
                Condition.Requires(newCompany.Website, nameof(newCompany.Website)).IsNotNullOrEmpty();
                Condition.Requires(newCompany.Email, nameof(newCompany.Email)).IsNotNullOrEmpty();
                Condition.Requires(newCompany.PhoneNumber, nameof(newCompany.PhoneNumber)).IsNotEmpty();

                await _pendingCompanyRepository.AddAsync(newCompany);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<PendingCompany>> GetPendingCompaniesAsync() =>
            await _pendingCompanyRepository.AllAsync();
    }
}
