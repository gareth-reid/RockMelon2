using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Common.Validation
{
    public class IpAddressAttribute : StringLengthAttribute
    {
        public IpAddressAttribute()
            : base(39) //An IP v6 address can be 39 characters, E.g: 2001:0db8:85a3:0000:0000:8a2e:0370:7334
        {
        }
    }
}