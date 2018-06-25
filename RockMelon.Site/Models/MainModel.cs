using System;
using System.Collections.Generic;
using System.ComponentModel;
using Rockmelon.Business.Criteria;
using Rockmelon.Repository.Entities;

namespace RockMelon.Site.Models
{
    public class MainModel
    {
        public bool IsArchivedMode { get; set; }
        public MainModel()
        {
        }
        public MainModel(bool archivedMode)
        {
            IsArchivedMode = archivedMode;
        }
 
        public int? SelectedPageId { get; set; }
        public int? SelectedMenuId { get; set; }
        [DisplayName("Search")]
        public string SearchWords{ get; set; }
        
        public bool CanEdit { get; set; }
        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
        public bool CanArchive { get; set; }
        public string Message { get; set; }
        public string AggregatedSearchWords { get; set; }
        public IEnumerable<Recipe> SearchResults { get; set; } 
        public bool Search(string pageSearchWords)
        {
            return !String.IsNullOrEmpty(SearchWords) && pageSearchWords.ToLower().Contains(SearchWords.ToLower());
        }

       
        public bool IsActive(Recipe page)
        {
            return page.IsActive;
        }
    }
}