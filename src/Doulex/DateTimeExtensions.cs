namespace Doulex;

public static class DateTimeExtensions
{
    /// <summary>
    /// 获取指定日期所在月份的值
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static (DateTime, DateTime) GetMonthRange(this DateTime source)
    {
        var start = new DateTime(source.Year, source.Month, 1);
        var end = start.AddMonths(1).AddMilliseconds(-1);

        return (start, end);
    }
}
