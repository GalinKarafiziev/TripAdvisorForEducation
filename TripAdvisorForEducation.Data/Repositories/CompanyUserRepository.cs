using System.Linq;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Base;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Data.Repositories
{
    public class CompanyUserRepository : GenericRepository<CompanyUser>, ICompanyUserRepository
    {
        public CompanyUserRepository(TripAdvisorForEducationDbContext context) 
            : base(context)
        {
        }

        public IQueryable<Product> GetCompanyProducts(string companyId)
        {
            var company = GetById(companyId);

            Context
                .Entry(company)
                .Collection(x => x.Products)
                .Load();

            return company.Products.AsQueryable();
        }
    }
}
