using System.Collections.Generic;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class AcademicsUserService : IAcademicsUserService
    {
        private readonly IAcademicsUserRepository _academicUserRepository;

        public AcademicsUserService(IAcademicsUserRepository academicsUserRepository) => 
            _academicUserRepository = academicsUserRepository;

        public async Task<IEnumerable<AcademicsUser>> GetAcademicsUsersAsync() => 
            await _academicUserRepository.AllAsync();
    }
}
