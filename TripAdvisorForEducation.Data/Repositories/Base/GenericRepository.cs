using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TripAdvisorForEducation.Data.Repositories.Contracts;

namespace TripAdvisorForEducation.Data.Repositories.Base
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public GenericRepository(TripAdvisorForEducationDbContext context)
        {
            Context = context ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            DbSet = Context.Set<T>();
        }

        protected DbSet<T> DbSet { get; set; }

        protected TripAdvisorForEducationDbContext Context { get; set; }

        public async virtual Task<IEnumerable<T>> AllAsync() => await DbSet.ToListAsync();

        public async virtual Task<T> GetByIdAsync(string id) => await DbSet.FindAsync(id);

        public async virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => 
            await DbSet.FirstOrDefaultAsync(predicate);

        public async virtual Task AddAsync(T entity)
        {
            var entry = Context.Entry(entity);

            if (entry.State != EntityState.Detached)
                entry.State = EntityState.Added;
            else
                await DbSet.AddAsync(entity);

            await Context.SaveChangesAsync();
        }

        public async virtual Task UpdateAsync(T entity)
        {
            var entry = Context.Entry(entity);

            if (entry.State == EntityState.Detached)
                DbSet.Attach(entity);

            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();   
        }

        public async virtual Task DeleteAsync(T entity)
        {
            var entry = Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
                entry.State = EntityState.Deleted;
            else
                DbSet.Remove(entity);

            await Context.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
                await DeleteAsync(entity);
        }

        public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();
    }
}
