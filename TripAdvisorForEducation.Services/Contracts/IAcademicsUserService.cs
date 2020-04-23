using System.Collections.Generic;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Services
{
    public interface IAcademicsUserService
    {
        Task<IEnumerable<AcademicsUser>> GetAcademicsUsersAsync();
    }
}
