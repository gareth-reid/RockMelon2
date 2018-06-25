using System;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using EntityFramework.Common.Validation.BaseAuditableEntity;

namespace EntityFramework.Common.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        protected BaseEntity()
        {
            IsActive = true;
        }

        #region IBaseEntity Members
        
        public int Id { get; set; }

        public DateTimeOffset LastUpdatedOn { get; set; }

        [Required]
        [LastUpdatedByUserId]
        public string LastUpdatedByUserId { get; set; }

        public bool IsActive { get; set; }

        #endregion
    }
}