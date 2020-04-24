using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Base;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Data.Repositories
{
    public class PendingCompanyRepository : GenericRepository<PendingCompany>, IPendingCompanyRepository
    {
        public PendingCompanyRepository(TripAdvisorForEducationDbContext context)
            : base(context)
        {
        }
    }
}
