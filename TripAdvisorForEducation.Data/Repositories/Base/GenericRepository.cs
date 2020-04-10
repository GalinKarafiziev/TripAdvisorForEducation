using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
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

        public virtual IQueryable<T> All() => this.DbSet.AsQueryable();

        public virtual T GetById(string id) => this.DbSet.Find(id);

        public virtual void Add(T entity)
        {
            EntityEntry entry = Context.Entry(entity);

            if (entry.State != EntityState.Detached)
                entry.State = EntityState.Added;
            else
                DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            EntityEntry entry = Context.Entry(entity);

            if (entry.State == EntityState.Detached)
                DbSet.Attach(entity);

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            EntityEntry entry = Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
                entry.State = EntityState.Deleted;
            else
                DbSet.Attach(entity);
                DbSet.Remove(entity);
        }

        public virtual void Delete(string id)
        {
            var entity = GetById(id);

            if (entity != null)
                Delete(entity);
        }

        public int SaveChanges() => Context.SaveChanges();
    }
}
