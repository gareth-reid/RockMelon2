using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Common.Validation
{
    public class ExternalIdentifierAttribute : StringLengthAttribute
    {
        public ExternalIdentifierAttribute()
            : base(20)
        {
        }
    }
}