//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EntityFramework.Common.Entities;


namespace Rockmelon.Repository.Entities
{
    public partial class IngredientQuantity : IBaseEntity
    {
        public int IngredientId { get; set; }
        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }
        
        public string UnitOfMeasure { get; set; }
        public int Amount { get; set; }
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }

        public int Id { get; private set; }
        public DateTimeOffset LastUpdatedOn { get; set; }
        public string LastUpdatedByUserId { get; set; }
        public bool IsActive { get; set; }
    }
}