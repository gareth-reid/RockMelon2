﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework.Common.Context;
using EntityFramework.Common.Entities;
using EntityFramework.Common.Queries;

namespace EntityFramework.Common.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
    {
        private readonly Lazy<IBaseDbContext> _context;

        public GenericRepository(Lazy<IBaseDbContext> context)
        {
            _context = context;
        }

        public virtual T Get(IQuery<T> query, params Expression<Func<T, object>>[] associations)
        {
            return Query(query, associations).SingleOrDefault();
        }

        public TOutput Get<TOutput>(IQuery<T, TOutput> query) where TOutput : IBaseEntity
        {
            return Query(query).SingleOrDefault();
        }

        public virtual T Get(int id, params Expression<Func<T, object>>[] associations)
        {
        	if (associations.Any() == false)
        		return _context.Value.Set<T>().Find(id);

        	//http://blogs.msdn.com/b/adonet/archive/2011/01/31/using-dbcontext-in-ef-feature-ctp5-part-6-loading-related-entities.aspx
        	
			var query = associations.Aggregate(_context.Value.Set<T>().AsQueryable(), (current, path) => current.Include(path));
        	return query.SingleOrDefault(i => i.Id == id);
        }

        public IQueryable<T> Get(IEnumerable<int> ids)
        {
            // Note: At some stage this may need to be made a bit smarter so it could deal with large list of ids
            return _context.Value.Set<T>().Where(e => ids.Contains(e.Id));
        }

        public IQueryable<T> Query(IQuery<T> query, params Expression<Func<T, object>>[] associations)
        {
            var queryWithAssociations = associations.Aggregate(_context.Value.Set<T>().AsQueryable(), (current, path) => current.Include(path));
            return query.ApplyPredicate(queryWithAssociations);
        }

        public IQueryable<TOutput> Query<TOutput>(IQuery<T, TOutput> query) where TOutput : IBaseEntity
        {
            return query.ApplyPredicate(_context.Value.Set<T>());
        }

        public bool Any(IQuery<T> query)
        {
            return query.ApplyPredicate(_context.Value.Set<T>()).Any();
        }

        public virtual void Add(T entity)
        {
            _context.Value.Set<T>().Add(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            // I do not want the result of GetAll to be IQueriable<T> otherwise dev may just start using GetAll from everywhere instead of implementing queries properly
            return _context.Value.Set<T>();
        }

        public virtual T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] associations)
        {
            var query = associations.Aggregate(_context.Value.Set<T>().AsQueryable(), (current, path) => current.Include(path));
            return query.SingleOrDefault(predicate);
        }

        public virtual void Delete(int id)
        {
            var existing = _context.Value.Set<T>().Find(id);
            _context.Value.Set<T>().Remove(existing);
        }
    }

}