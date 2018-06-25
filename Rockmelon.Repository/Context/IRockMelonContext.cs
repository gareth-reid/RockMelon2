using System.Linq;
using EntityFramework.Common.Context;
using Rockmelon.Repository.Entities;

namespace RockMelon.Repository.Context
{
    public interface IRockMelonContext : IBaseDbContext
    {
        IQueryable<Ingredient> Ingredient { get; }
        IQueryable<Recipe> Recipe { get; }
        IQueryable<IngredientQuantity> IngredientQuantity { get; }
        IQueryable<Feedback> Feedback { get; }
    }
}
