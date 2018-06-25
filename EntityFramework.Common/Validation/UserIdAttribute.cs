using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Common.Validation
{
    public class UserIdAttribute : StringLengthAttribute
    {
        public UserIdAttribute(bool isRequired)
            : base(20)
        {
            if (isRequired)
            {
                MinimumLength = 1;
            }
        }
    }
}