using System.Collections.Generic;
using System.Threading.Tasks;

namespace TripAdvisorForEducation.Data.Repositories.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> AllAsync();

        Task<T> GetByIdAsync(string id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteAsync(string id);

        Task<int> SaveChangesAsync();
    }
}
