using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework.Common.Entities;
using EntityFramework.Common.Queries;

namespace EntityFramework.Common.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] associations);
        TEntity Get(IQuery<TEntity> query, params Expression<Func<TEntity, object>>[] associations);
        TOutput Get<TOutput>(IQuery<TEntity, TOutput> query)
            where TOutput : IBaseEntity;

        TEntity Get(int id, params Expression<Func<TEntity, object>>[] associations);
        IQueryable<TEntity> Get(IEnumerable<int> ids);

        IQueryable<TEntity> Query(IQuery<TEntity> query, params Expression<Func<TEntity, object>>[] associations);
        IQueryable<TOutput> Query<TOutput>(IQuery<TEntity, TOutput> query)
            where TOutput : IBaseEntity;

        bool Any(IQuery<TEntity> query);

        void Add(TEntity entity);
        void Delete(int id);
    }
}