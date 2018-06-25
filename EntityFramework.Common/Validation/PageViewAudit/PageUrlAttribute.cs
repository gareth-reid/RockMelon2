using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Common.Validation.PageViewAudit
{
    public class PageUrlAttribute : StringLengthAttribute
    {
        public PageUrlAttribute()
            : base(2000) //max length of a URL is 2000 characters: http://www.faqs.org/rfcs/rfc2616.html
        {
        }
    }
}