using System;

namespace EntityFramework.Common.Application
{
    public class TimeFactory
    {
        public static Func<DateTimeOffset> Now = () => DateTimeOffset.Now;
    }
}