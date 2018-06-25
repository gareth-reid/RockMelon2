using System;
using System.Collections.Generic;
using Rockmelon.Repository.Entities;

namespace Rockmelon.Business.Criteria
{
    public class MenuCriteria : IRecipeCriteria
    {
        public IEnumerable<Func<Recipe, object>> BuildCriteria(IRecipeCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
