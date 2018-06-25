using System;
using System.Collections.Generic;
using Rockmelon.Repository.Entities;

namespace Rockmelon.Business.Criteria
{
    public interface IRecipeCriteria
    {
        IEnumerable<Func<Recipe, object>> BuildCriteria(IRecipeCriteria criteria);
    }
}
