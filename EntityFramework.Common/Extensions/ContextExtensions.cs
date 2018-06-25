using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using EntityFramework.Common;
using EntityFramework.Common.Context;

namespace EntityFramework.Common.Extensions
{
    /// <summary>
    ///   Helpful extensions for DataContexts
    ///   GetTableName: http://ruijarimba.wordpress.com/2012/03/18/entity-framework-get-mapped-table-name-from-an-entity/
    /// </summary>
    public static class ContextExtensions
    {
        public static string GetTableName<T>(this DbContext context) where T : class
        {
            var objectContext = ((IObjectContextAdapter) context).ObjectContext;
            return objectContext.GetTableName<T>();
        }

        public static string GetTableName<T>(this ObjectContext context) where T : class
        {
            var sql = context.CreateObjectSet<T>().ToTraceString();
            var regex = new Regex("FROM (?<table>.*) AS");
            var match = regex.Match(sql);
            var table = match.Groups["table"].Value;
            return table;
        }

        /// <summary>
        /// Executs a SQL command to add an index to the context's underlying database
        /// </summary>
        /// <typeparam name="T">The entity type of the table</typeparam>
        /// <param name="context">The current DbContext</param>
        /// <param name="field">The field you want to make the index for</param>
        /// <param name="isUnique">Whether it is a unique index or not</param>
        public static void CreateIndex<T>(this DbContext context, string field, bool isUnique) where T : class
        {
            if (context == null) throw new ArgumentNullException("context");
            context.Database.ExecuteSqlCommand(String.Format("CREATE {2}INDEX IX_{0} ON {1} ({0})", field, context.GetTableName<T>(), isUnique ? "UNIQUE " : string.Empty));
        }
        
        
    }
}