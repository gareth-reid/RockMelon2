using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Objects;
using System.IO;
using System.Reflection;
using EntityFramework.Common;

namespace EntityFramework.Common.Context
{

    public class DropCreateTablesOnlyIfModelChanges<T, TMc> : IDatabaseInitializer<T>
        where T : DbContext
        where TMc : DbMigrationsConfiguration<T>
    {
        public void InitializeDatabase(T context)
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;

            try
            {
                if (!HasDatabaseChanged(context))
                    return;
            }
            catch (NotSupportedException)
            {
                //means that __ModelHistory does not exist, so Model has changed
            }

            DeleteExistingTables(objectContext);
            CreateTables();

            Seed(context);
            context.SaveChanges();
        }

        protected virtual void Seed(T context)
        {
        }

        protected virtual bool HasDatabaseChanged(T context)
        {
            return !context.Database.CompatibleWithModel(true);
        }

        private static void CreateTables()
        {
            new DbMigrator(Activator.CreateInstance<TMc>()).Update();
        }


        private static void DeleteExistingTables(ObjectContext objectContext)
        {
            try
            {
                objectContext.ExecuteStoreCommand(Resources.DropAllConstraints);
            }
            catch(Exception ex)
            {
                throw new ApplicationException(string.Format("Exception trying to run query: {0}{1}", Environment.NewLine, Resources.DropAllConstraints), ex);
            }


            try
            {
                objectContext.ExecuteStoreCommand(Resources.DropAllTables);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Exception trying to run query: {0}{1}", Environment.NewLine, Resources.DropAllTables), ex);
            }
            
        }
    }
}