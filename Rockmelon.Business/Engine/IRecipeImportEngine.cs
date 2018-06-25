using System;
using System.Collections.Generic;
using System.Linq;
using Rockmelon.Business.Criteria;
using Rockmelon.Repository.Entities;

namespace Rockmelon.Business.Engine
{
    public interface IRecipeImportEngine
    {
        void ExtractRecipe(string recipeContent);
    }
}
