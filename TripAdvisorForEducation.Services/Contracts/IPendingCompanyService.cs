using System.Collections.Generic;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Services.Contracts
{
    public interface IPendingCompanyService
    {
        Task<IEnumerable<PendingCompany>> GetPendingCompaniesAsync();

        Task<bool> AddPendingCompanyAsync(PendingCompany newCompany);
    }
}
