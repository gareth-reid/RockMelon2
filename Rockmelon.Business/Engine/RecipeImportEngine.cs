using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Rockmelon.Business.Criteria;
using Rockmelon.Repository.Entities;

namespace Rockmelon.Business.Engine
{
    public class RecipeImportEngine : IRecipeImportEngine
    {
        public string StripOutHtml(string html)
        {
            String result = Regex.Replace(html, @"<[^>]*>", String.Empty);
            result = result.Replace("\n", "");
            result = result.Replace("\r", ";");
            return result;
        }
        public void ExtractRecipe(string recipeContent)
        {
            recipeContent = StripOutHtml(recipeContent);
            var ints = new List<int>();
            var currentInt = String.Empty;
            var recipeCharArray = recipeContent.ToCharArray();
            foreach (var c in recipeCharArray)
            {
                if (c.IsInt())
                {
                    currentInt += c;
                }
                else
                {
                    var num = currentInt.ToInt32(0);
                    if (num > 0)
                    {
                        ints.Add(num);
                    }
                    currentInt = String.Empty;
                }
                
            }
        }

        
    }

    public static class Extensions
    {
        public static int ToInt32(this object val, int defaultValue)
        {
            int iValue = 0;
            if (int.TryParse(val.ToString(), out iValue))
            {
                return iValue;
            }
            return defaultValue;
        }

        public static bool IsInt(this object val)
        {
            int iValue = 0;
            if (int.TryParse(val.ToString(), out iValue))
            {
                return true;
            }
            return false;
        }
    }
}
