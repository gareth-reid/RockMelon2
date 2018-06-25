using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System;
using EntityFramework.Common.Entities;

namespace EntityFramework.Common.Context
{
    public interface IBaseDbContext : IUnitOfWork, IDisposable {
        BaseDbContext.IEntityChangeListener ChangeListener { get; set; }
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbChangeTracker DatabaseChangeTracker { get; }
        bool AllowDebugInfo { get; set; }
        Database Database { get; }
    }
}