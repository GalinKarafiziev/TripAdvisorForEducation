using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TripAdvisorForEducation.Data.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public async static Task<TEntity> LoadEntityCollectionAsync<TEntity, TProperty>(
            this TEntity entity, 
            DbContext context, 
            Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression) 
            where TEntity : class
            where TProperty : class
        {
            await context
                .Entry(entity)
                .Collection(propertyExpression)
                .LoadAsync();

            return entity;
        }

        public async static Task<TEntity> LoadEntityReferenceAsync<TEntity, TProperty>(
            this TEntity entity,
            DbContext context,
            Expression<Func<TEntity, TProperty>> propertyExpression)
            where TEntity : class
            where TProperty : class
        {
            await context
                .Entry(entity)
                .Reference(propertyExpression)
                .LoadAsync();

            return entity;
        }
    }
}
