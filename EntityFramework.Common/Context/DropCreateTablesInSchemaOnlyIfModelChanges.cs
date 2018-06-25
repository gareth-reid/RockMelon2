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

    public class DropCreateTablesInSchemaOnlyIfModelChanges<T, TMc> : IDatabaseInitializer<T>
        where T : DbContext
        where TMc : DbMigrationsConfiguration<T> {

        #region SQL ugliness

        private const String DropTablesSql = @"
DECLARE @SqlStatement VARCHAR(MAX)
SELECT @SqlStatement = 
    COALESCE(@SqlStatement, '') + 'DROP TABLE [{0}].' + QUOTENAME(TABLE_NAME) + ';' + CHAR(13)
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME != '__MigrationHistory'
EXEC(@SqlStatement)";
        #endregion

        private readonly string _schema;

        public DropCreateTablesInSchemaOnlyIfModelChanges(string schema) {
            if (String.IsNullOrEmpty(schema)) throw new ArgumentException("schema must not be null or empty.");
            _schema = schema;
        }

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

            DeleteExistingTables(objectContext, _schema);
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


        private static void DeleteExistingTables(ObjectContext objectContext, string schema) {

            var command = String.Format(DropTablesSql, schema);

            objectContext.ExecuteStoreCommand(Resources.DropAllConstraints);
            objectContext.ExecuteStoreCommand(command);
        }
    }
}