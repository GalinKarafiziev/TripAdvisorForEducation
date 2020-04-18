using System;
using System.Collections.Generic;
using System.Text;
using TripAdvisorForEducation.Data.Models;

namespace TripAdvisorForEducation.Services
{
    public interface IAcademicsUserService
    {
        List<AcademicsUser> GetAcademicsUsers();
    }
}
