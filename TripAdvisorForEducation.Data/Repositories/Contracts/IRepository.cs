using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TripAdvisorForEducation.Data.Repositories.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> AllAsync();

        Task<T> GetByIdAsync(string id);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteAsync(string id);

        Task<int> SaveChangesAsync();
    }
}
