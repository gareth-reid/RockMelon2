using System;
using EntityFramework.Common.Extensions;
using EntityFramework.Common.Context;
using EntityFramework.Common.Entities;
using Rockmelon.Repository.Entities;
using RockMelon.Repository.Migrations;

namespace RockMelon.Repository.Context
{
    public class RockMelonContextInitializer :
#if DEBUG
 DropCreateTablesOnlyIfModelChanges<RockMelonContext, Configuration>
#else
        DropCreateTablesOnlyIfModelChanges<RockMelonContext, Configuration>
#endif
    {
        protected override void Seed(RockMelonContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            NotSupportedInEntityFrameworkStuffInitializer.Initialize(context);

            AddPermanentStaticData(context);
            AddDummyTestData(context);
        }

        private static void AddPermanentStaticData(RockMelonContext context)
        {
            //will make editable in phase 2
           
        }

        private static void AddDummyTestData(RockMelonContext context)
        {
        
        }
    }
}
