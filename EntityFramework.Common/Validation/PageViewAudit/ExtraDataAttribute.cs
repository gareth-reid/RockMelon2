using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Common.Validation.PageViewAudit
{
    public class ExtraDataAttribute : StringLengthAttribute
    {
        public ExtraDataAttribute()
            : base(1000)
        {
        }
    }
}