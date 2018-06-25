using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using EntityFramework.Common.Application;
using EntityFramework.Common.Entities;
using EntityFramework.Common.Extensions;

namespace EntityFramework.Common.Context
{
    public abstract class BaseDbContext : DbContext, IBaseDbContext
    {
        protected BaseDbContext()
        {
            QueryableExtensions.Includer = new DbIncluder();
        }

        #region IBaseDbContext Members

        public IEntityChangeListener ChangeListener { get; set; }

        IDbSet<TEntity> IBaseDbContext.Set<TEntity>()
        {
            return Set<TEntity>();
        }

        public DbChangeTracker DatabaseChangeTracker
        {
            get { return ChangeTracker; }
        }

        public bool AllowDebugInfo { get; set; }

        public void Save()
        {            
            try
            {
                var auditableChanges = DatabaseChangeTracker.Entries<IBaseEntity>();
                foreach (var entry in auditableChanges)
                {
                    if (entry.Entity.Id > 0)
                    {
                        entry.State = EntityState.Modified;
                    }
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.IsActive = true;
                            break;
                        case EntityState.Deleted:
                            entry.Entity.IsActive = false;
                            break;
                        case EntityState.Modified:
                            {
                                break;
                            }
                    }

                    //Always make sure the last udpated by and on are set no matter what was changed
                    //entry.Entity.LastUpdatedByUserId = _currentUser.UserId;
                    entry.Entity.LastUpdatedOn = TimeFactory.Now();

                    if (ChangeListener != null)
                        ChangeListener.EntityChanged(entry);

                }

                if (AllowDebugInfo)
                {
                    Debug.WriteLine("BaseDbContext Hash Code Saving: {0}", GetHashCode());
                    try
                    {
                        var changes =
                            ChangeTracker.Entries().Where(
                                i =>
                                i.State == EntityState.Added || i.State == EntityState.Modified ||
                                i.State == EntityState.Deleted);
                        foreach (var entry in changes)
                        {
                            var finalValueData = new StringBuilder();
                            if (entry.CurrentValues != null && entry.CurrentValues.PropertyNames != null)
                            {
                                var isFirst = true;
                                foreach (var currPropertyName in entry.CurrentValues.PropertyNames)
                                {
                                    finalValueData.Append(Environment.NewLine);
                                    if (isFirst)
                                    {
                                        isFirst = false;
                                    }
                                    else
                                    {
                                        finalValueData.Append(", ");
                                    }

                                    finalValueData.Append(" [");
                                    finalValueData.Append(currPropertyName);
                                    finalValueData.Append("] = '");

                                    var currValueAsObject = entry.CurrentValues[currPropertyName];
                                    var currValue = currValueAsObject == null ? "[null]" : currValueAsObject.ToString();
                                    var prevValue = entry.State == EntityState.Modified && entry.OriginalValues != null
                                                        ? entry.OriginalValues[currPropertyName].ToString()
                                                        : "[null]";

                                    finalValueData.Append(currValue);
                                    finalValueData.Append("'");

                                    if (entry.State == EntityState.Modified &&
                                        !currValue.Equals(prevValue, StringComparison.CurrentCulture))
                                    {
                                        finalValueData.Append(" (was '");
                                        finalValueData.Append(prevValue);
                                        finalValueData.Append("')");
                                    }

                                }
                            }

                            var message = string.Format("{0}*{1}* {2}: {3}",
                                                        Environment.NewLine,
                                                        entry.State,
                                                        entry.Entity == null ? "[unknown]" : entry.Entity.GetType().Name,
                                                        finalValueData);

                            Trace.WriteLine(message);
                            Debug.WriteLine(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        var errorMsg = string.Concat("!!! Unexpected Exception constructing Debug Info !!! - ", ex.Message);
                        Trace.WriteLine(errorMsg);
                        Debug.WriteLine(errorMsg);
                    }
                }

                base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var validationExceptions = (from validationErrors in dbEx.EntityValidationErrors
                                            from validationError in validationErrors.ValidationErrors
                                            select
                                                new ValidationException(string.Format("Property = {0}; Error = {1}",
                                                                                      validationError.PropertyName,
                                                                                      validationError.ErrorMessage))).
                    Cast<Exception>().ToList();
                throw new AggregateException(dbEx.Message, validationExceptions);
            }
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (AllowDebugInfo)
            {
                Trace.WriteLine("Disposing");
                Debug.WriteLine("Disposing");
            }
        }

        #region Nested type: DbIncluder

        protected class DbIncluder : QueryableExtensions.IIncluder
        {
            #region IIncluder Members

            public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path)
                where T : class
            {
                return DbExtensions.Include(source, path);
            }

            #endregion
        }

        #endregion

        #region Nest type: EntityChanger
        public interface IEntityChangeListener
        {
            void EntityChanged<TEntity>(DbEntityEntry<TEntity> entity) where TEntity : class, IBaseEntity;
        }
        #endregion
    }
}