using System.Collections.Generic;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.ViewModels;

namespace TripAdvisorForEducation.Services.Contracts
{
    public interface IPendingCompanyService
    {
        Task<IEnumerable<PendingCompany>> GetPendingCompaniesAsync();

        Task<bool> AddPendingCompanyAsync(PendingCompanyViewModel pendingCompanyViewModel);

        Task<PendingCompany> GetPendingCompanyAsync(string companyId);

        Task<bool> DeclinePendingCompany(string companyId);

        Task<bool> ApprovePendingCompany(string email, string token);

        Task<bool> IsTokenValid(string token);
    }
}
