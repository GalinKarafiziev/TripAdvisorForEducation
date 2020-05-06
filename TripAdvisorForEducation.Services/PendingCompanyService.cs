using AutoMapper;
using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;
using TripAdvisorForEducation.Data.ViewModels;
using TripAdvisorForEducation.Services.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class PendingCompanyService : IPendingCompanyService
    {
        private readonly IPendingCompanyRepository _pendingCompanyRepository;
        private readonly IMapper _mapper;
        private readonly ITokenGeneratorService _tokenService;

        public PendingCompanyService(IPendingCompanyRepository pendingCompanyRepository, IMapper mapper, ITokenGeneratorService tokenService)
        {
            _pendingCompanyRepository = pendingCompanyRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<PendingCompany>> GetPendingCompaniesAsync() =>
            await _pendingCompanyRepository.AllAsync();

        public async Task<PendingCompany> GetPendingCompanyAsync(string companyId) =>
            await _pendingCompanyRepository.GetByIdAsync(companyId);

        public async Task<bool> AddPendingCompanyAsync(PendingCompanyViewModel newCompany)
        {
            try
            {
                Condition.Requires(newCompany.CompanyName, nameof(newCompany.CompanyName)).IsNotNullOrEmpty();
                Condition.Requires(newCompany.Website, nameof(newCompany.Website)).IsNotNullOrEmpty();
                Condition.Requires(newCompany.Email, nameof(newCompany.Email)).IsNotNullOrEmpty();
                Condition.Requires(newCompany.PhoneNumber, nameof(newCompany.PhoneNumber)).IsNotEmpty();

                var pendingCompany = _mapper.Map<PendingCompany>(newCompany);
                pendingCompany.Token = _tokenService.GenerateToken(50);
                pendingCompany.IsTokenActive = true;

                await _pendingCompanyRepository.AddAsync(pendingCompany);
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ApprovePendingCompany(string email, string token)
        {
            try
            {
                Condition.Requires(token, nameof(token)).IsNotNullOrEmpty();

                var pendingCompany = await _pendingCompanyRepository.FirstOrDefaultAsync(x => x.Email == email && x.Token == token);
                pendingCompany.IsTokenActive = false;

                await _pendingCompanyRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeclinePendingCompany(string companyId)
        {
            try
            {
                var pendingCompany = await _pendingCompanyRepository.GetByIdAsync(companyId);
                pendingCompany.IsTokenActive = false;

                await _pendingCompanyRepository.UpdateAsync(pendingCompany);

                // TODO: Send decline email

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> IsTokenValid(string token)
        {
            try
            {
                Condition.Requires(token, nameof(token)).IsNotNullOrEmpty();

                var pendingCompany = (await GetPendingCompaniesAsync()).Where(x => x.Token == token).FirstOrDefault();

                if (pendingCompany.IsTokenActive)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
