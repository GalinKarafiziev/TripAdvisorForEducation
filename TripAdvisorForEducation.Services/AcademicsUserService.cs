using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
