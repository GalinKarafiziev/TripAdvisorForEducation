using System.Linq;
using TripAdvisorForEducation.Data.Models;
using TripAdvisorForEducation.Data.Repositories.Base;
using TripAdvisorForEducation.Data.Repositories.Contracts;
using TripAdvisorForEducation.Data.Repositories.Extensions;

namespace TripAdvisorForEducation.Data.Repositories
{
    public class CompanyUserRepository : GenericRepository<CompanyUser>, ICompanyUserRepository
    {
        public CompanyUserRepository(TripAdvisorForEducationDbContext context) 
            : base(context)
        {
        }

        public IQueryable<Product> GetCompanyProducts(string companyId) => 
            GetById(companyId).LoadEntityCollection(Context, x => x.Products).Products.AsQueryable();
    }
}
