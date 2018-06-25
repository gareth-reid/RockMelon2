using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using EntityFramework.Common.Context;
using EntityFramework.Common.Entities;
using RockMelon.Repository.Context;
using Rockmelon.Repository.Entities;

namespace RockMelon.Repository.Context
{
    public class RockMelonContext : BaseDbContext, IRockMelonContext, IPageViewAuditableContext {
        public RockMelonContext()
        {
#if DEBUG
            AllowDebugInfo = false;
            Debug.WriteLine("New Instance of RockMelonContext with NO user: {0}", GetHashCode());
#endif
        }


        public DbSet<PageViewAudit> PageViewAudit { get; set; }

        public DbSet<Ingredient> Ingredient { get; set; }
        IQueryable<Ingredient> IRockMelonContext.Ingredient { get { return Ingredient; } }

        public DbSet<Recipe> Recipe { get; set; }
        IQueryable<Recipe> IRockMelonContext.Recipe { get { return Recipe; } }

        public DbSet<IngredientQuantity> IngredientQuantity { get; set; }
        IQueryable<IngredientQuantity> IRockMelonContext.IngredientQuantity { get { return IngredientQuantity; } }

        public DbSet<Feedback> Feedback { get; set; }
        IQueryable<Feedback> IRockMelonContext.Feedback { get { return Feedback; } }

    }
}
