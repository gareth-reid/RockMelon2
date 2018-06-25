using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace EntityFramework.Common.Context
{
    public class DropCreateTablesAlways<T, TMc> : DropCreateTablesOnlyIfModelChanges<T, TMc> 
        where T : DbContext
        where TMc : DbMigrationsConfiguration<T>
    {
        protected override bool HasDatabaseChanged(T context)
        {
            return true;
        }
    }
}
