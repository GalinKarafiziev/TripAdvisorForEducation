using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Product>> GetCompanyProductsAsync(string companyId)
        {
            var company = await GetByIdAsync(companyId);
            await company.LoadEntityCollectionAsync(Context, x => x.Products);

            return company.Products;
        }

        // TODO: GetCompany with loaded products
    }
}
