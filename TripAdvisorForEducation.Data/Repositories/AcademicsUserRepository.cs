using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Base;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Data.Repositories
{
    public class AcademicsUserRepository : GenericRepository<AcademicsUser>, IAcademicsUserRepository
    {
        public AcademicsUserRepository(TripAdvisorForEducationDbContext context) 
            : base(context)
        {
        }
    }
}
