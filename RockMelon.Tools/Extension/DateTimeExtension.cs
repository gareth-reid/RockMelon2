using System;

namespace RockMelon.Tools.Extension
{
    public static class DateTimeExtension
    {
        private static DateTime _now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public static DateTime SubtractDays(this DateTime? dateTime, int days, bool throwExceptionOnNull = false)
        {
            try
            {
                return dateTime.Value.AddDays(-days);
            }
            catch 
            {
                if (throwExceptionOnNull)
                {
                    throw new NullReferenceException();
                }
                DateTime? now = _now;
                return now.SubtractDays(days, true); //re-call with current date -if throws another exception......kill it (by passing true) 
            }
        }

        public static DateTime GetFirstDateOfMonth(this DateTime? currentDate, bool throwExceptionOnNull = false)
        {
            try
            {
                return currentDate.Value.AddDays((-1) * currentDate.Value.Day + 1);
            }
            catch
            {
                if (throwExceptionOnNull)
                {
                    throw new NullReferenceException();
                }
                DateTime? now = _now;
                return now.GetFirstDateOfMonth(true);
            }
        }

        public static DateTime GetLastDateOfMonth(this DateTime? currentDate, bool throwExceptionOnNull = false)
        {
            try
            {
                DateTime? current = currentDate.Value.AddMonths(1);
                return current.GetFirstDateOfMonth().AddDays(-1);
            }
            catch
            {
                if (throwExceptionOnNull)
                {
                    throw new NullReferenceException();
                }
                DateTime? now = _now;
                return now.GetLastDateOfMonth(true);
            }
        }

        public static int WeekOfYear(this DateTime? currentDate, bool throwExceptionOnNull = false)
        {
            try
            {
                int dayOfYear = currentDate.Value.DayOfYear;
                var week = (dayOfYear + 6) / 7;
                return week > 52 ? 52 : week;
            }
            catch
            {
                if (throwExceptionOnNull)
                {
                    throw new NullReferenceException();
                }
                DateTime? now = _now;
                return now.WeekOfYear(true);
            }
        }
    }
}
