namespace Doulex.Toolkit.DateTimes;

/// <summary>
/// 
/// </summary>
public static class JavaScriptDateTimeUtils
{
    private static readonly long InitialJavaScriptDateTicks = 621355968000000000;

    public static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime)
    {
        var javaScriptTicks = (dateTime.Ticks - InitialJavaScriptDateTicks) / 10000;
        return javaScriptTicks;
    }

    public static DateTime ConvertJavaScriptTicksToDateTime(long javaScriptTicks, DateTimeKind kind = DateTimeKind.Utc)
    {
        var dateTime = new DateTime((javaScriptTicks * 10000) + InitialJavaScriptDateTicks, kind);
        return dateTime;
    }

    public static DateTime? ToDateTime(this long? source, DateTimeKind kind = DateTimeKind.Utc)
    {
        if (source == null)
        {
            return null;
        }

        return ConvertJavaScriptTicksToDateTime(source.Value, kind);
    }
        
    public static long? ToJavaScriptTicks(this DateTime? source)
    {
        if (source == null)
        {
            return null;
        }

        return ConvertDateTimeToJavaScriptTicks(source.Value);
    }
}