using RockMelon.Repository.Context;

namespace RockMelon.Repository.Context
{
    public static class NotSupportedInEntityFrameworkStuffInitializer
    {
        public static void Initialize(RockMelonContext context)
        {
            //context.Database.ExecuteSqlCommand("ALTER TABLE Patient ADD CONSTRAINT UQ_UrNumber UNIQUE(UrNumber)");

        }
    }
}