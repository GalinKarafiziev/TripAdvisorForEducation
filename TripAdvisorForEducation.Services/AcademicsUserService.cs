using System.Collections.Generic;
using System.Linq;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class AcademicsUserService : IAcademicsUserService
    {
        private readonly IAcademicsUserRepository _academicUserRepository;

        public AcademicsUserService(IAcademicsUserRepository academicsUserRepository)
        {
            this._academicUserRepository = academicsUserRepository;
        }

        public List<AcademicsUser> GetAcademicsUsers() => _academicUserRepository.All().ToList();
    }
}
