using System.Collections.Generic;
using Rockmelon.Business.Criteria;
using Rockmelon.Repository.Entities;

namespace Rockmelon.Business.Engine
{
    public interface ISearchEngine
    {
        IEnumerable<MyPair<Recipe, bool>> Search(IEnumerable<Recipe> menuItems, string searchWords);
        bool WordFound(string word, string searchWords);
    }
}