using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Common.Validation.PageViewAudit
{
    public class HttpVerbAttribute : StringLengthAttribute
    {
        public HttpVerbAttribute()
            : base(10)
        {
        }
    }
}