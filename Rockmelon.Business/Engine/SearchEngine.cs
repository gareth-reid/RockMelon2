using System;
using System.Collections.Generic;
using System.Linq;
using Rockmelon.Business.Criteria;
using Rockmelon.Repository.Entities;

namespace Rockmelon.Business.Engine
{
    public class SearchEngine : ISearchEngine
    {
        //public IEnumerable<MyPair<Menu, bool>> Search(IEnumerable<Menu> menuItems, string searchWords)
        //{
        //    var menuItemsFiltered = menuItems.Select(m => new MyPair<Menu, bool>()
        //    {
        //        First = m,
        //        Second = !String.IsNullOrEmpty(searchWords)
        //                 && (m.Pages.Any() && m.Pages.Any(x => x.IsActive && WordFound(x.PageSearchWords, searchWords)))
        //    }).ToList();

        //    return menuItemsFiltered;
        //}

        public IEnumerable<MyPair<Recipe, bool>> Search(IEnumerable<Recipe> menuItems, string searchWords)
        {
            throw new NotImplementedException();
        }

        public bool WordFound(string word, string searchWords)
        {
            var words = String.IsNullOrEmpty(searchWords) ? new string[0] : searchWords.Split(' ');
            if (!words.Any())
            {
                return false;
            }
            
            foreach (var w in words)
            {
                var found = word.ToLower().Contains(w.ToLower());
                if(!found)
                {
                    return false;//one of the words was not found
                }//else keep checking
            }
            return true;
        }
    }
}
