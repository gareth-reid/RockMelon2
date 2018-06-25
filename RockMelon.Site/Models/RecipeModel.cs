using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Web.Mvc;

namespace RockMelon.Site.Models
{
    public class RecipeModel 
    {
        [AllowHtml]
       // [RenderMode(RenderModeAttribute.RenderMode.None)]
        public string RecipeContent { get; set; }
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public bool ReadOnly { get; set; }
       
    }
}