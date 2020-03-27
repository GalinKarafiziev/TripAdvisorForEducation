using System;
using System.Collections.Generic;
using System.Text;
using TripAdvisorForEducation.Data.Repositories.Contracts;
using TripAdvisorForEducation.Services.Contracts;

namespace TripAdvisorForEducation.Services
{
    public class CompanyUserService : ICompanyUserService
    {
        private readonly ICompanyUserRepository _companyUserRepository;

        public CompanyUserService(ICompanyUserRepository companyUserRepository)
        {
            this._companyUserRepository = companyUserRepository;
        }
    }
}
