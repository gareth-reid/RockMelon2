using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Common.Validation.PageViewAudit
{
    public class SubjectTypeAttribute : StringLengthAttribute
    {
        public SubjectTypeAttribute()
            : base(20)
        {
        }
    }
}