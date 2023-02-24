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
    }
}
