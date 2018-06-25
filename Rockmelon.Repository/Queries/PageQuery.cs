using System;
using System.Linq;
using EntityFramework.Common.Extensions;
using EntityFramework.Common.Queries;
using Rockmelon.Repository.Entities;

namespace RockMelon.Repository.Queries
{
    public class RecipeQuery : IQuery<Recipe>
    {
        private readonly Recipe _menu;

        public RecipeQuery(Recipe menu)
        {
            _menu = menu;
        }

        public IQueryable<Recipe> ApplyPredicate(IQueryable<Recipe> inputSet)
        {
            return inputSet.Where(p => p.IsActive && p.Id == _menu.Id);
        }
    }
}
