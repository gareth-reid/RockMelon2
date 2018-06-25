using System;
using System.Data;
using Rockmelon.Repository.Entities;

namespace Rockmelon.Business.Validators
{
    public class MenuValidator : IRecipeValidator
    {
        public void Validate(Recipe recipe)
        {
            //could but this into an engine
            //if (menu.Ratings != null && menu.Ratings.First().RatingId > 5)
            //{
            //    throw new DataException("Rating can not be greater then 5");
            //}
            if (String.IsNullOrEmpty(recipe.RecipeName))
            {
                throw new DataException("Name required");
            }
        }
    }
}
