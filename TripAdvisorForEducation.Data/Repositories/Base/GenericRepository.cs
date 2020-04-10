using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using TripAdvisorForEducation.Data.Contracts;

namespace TripAdvisorForEducation.Data.Repositories.Base
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public GenericRepository(TripAdvisorForEducationDbContext context)
        {
            this.Context = context ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            this.DbSet = this.Context.Set<T>();
        }

        protected DbSet<T> DbSet { get; set; }

        protected TripAdvisorForEducationDbContext Context { get; set; }

        public virtual IQueryable<T> All() => this.DbSet.AsQueryable();

        public virtual T GetById(string id) => this.DbSet.Find(id);

        public virtual void Add(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Detached)
                entry.State = EntityState.Added;

            else
            {
                this.DbSet.Add(entity);
                this.Context.SaveChanges();
            }
                
        }

        public virtual void Update(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
                this.DbSet.Attach(entity);

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
                entry.State = EntityState.Deleted;
            else
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
        }

        public virtual void Delete(string id)
        {
            var entity = this.GetById(id);

            if (entity != null)
                this.Delete(entity);
        }
    }
}
