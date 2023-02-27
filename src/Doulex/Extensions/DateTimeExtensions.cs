namespace Doulex
{
    /// <summary>
    /// The extension of date time.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns the range of the month for the specified date.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static (DateTime, DateTime) GetMonthRange(this DateTime source)
        {
            var start = new DateTime(source.Year, source.Month, 1);
            var end   = start.AddMonths(1).AddMilliseconds(-1);

            return (start, end);
        }

        /// <summary>
        /// Returns the last day of the month for the specified date.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime source)
        {
            return new DateTime(source.Year, source.Month, 1);
        }

        /// <summary>
        /// Returns the first day of the year for the specified date.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfYear(this DateTime source)
        {
            return new DateTime(source.Year, 1, 1);
        }

        /// <summary>
        /// Just change the timezone to UTC, keep the time unchanged.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime AsUniversalTime(this DateTime source)
        {
            // change the timezone to UTC
            return new DateTime(source.Ticks, DateTimeKind.Utc);
        }

        /// <summary>
        /// Just change the timezone to local, keep the time unchanged.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime AsLocalTime(this DateTime source)
        {
            // change the timezone to local
            return new DateTime(source.Ticks, DateTimeKind.Local);
        }
    }
}
