using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TripAdvisorForEducation.Data.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static TEntity LoadEntityCollection<TEntity, TProperty>(
            this TEntity entity, 
            DbContext context, 
            Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression) 
            where TEntity : class
            where TProperty : class
        {
            context
                .Entry(entity)
                .Collection(propertyExpression)
                .Load();

            return entity;
        }

        public static TEntity LoadEntityReference<TEntity, TProperty>(
            this TEntity entity,
            DbContext context,
            Expression<Func<TEntity, TProperty>> propertyExpression)
            where TEntity : class
            where TProperty : class
        {
            context
                .Entry(entity)
                .Reference(propertyExpression)
                .Load();

            return entity;
        }
    }
}
