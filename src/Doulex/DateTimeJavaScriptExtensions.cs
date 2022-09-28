namespace Doulex
{
    /// <summary>
    /// 一个把 javascript 时间戳转换为 DateTime 的工具类
    /// </summary>
    public static class DateTimeJavaScriptExtensions
    {
        private static readonly long InitialJavaScriptDateTicks = 621355968000000000;

        public static long ToJavaScriptTicks(this DateTime dateTime)
        {
            var javaScriptTicks = (dateTime.Ticks - InitialJavaScriptDateTicks) / 10000;
            return javaScriptTicks;
        }

        public static DateTime ToDateTime(this long javaScriptTicks, DateTimeKind kind = DateTimeKind.Utc)
        {
            var dateTime = new DateTime(javaScriptTicks * 10000 + InitialJavaScriptDateTicks, kind);
            return dateTime;
        }

        public static DateTime? ToDateTime(this long? source, DateTimeKind kind = DateTimeKind.Utc)
        {
            if (source == null)
            {
                return null;
            }

            return ToDateTime(source.Value, kind);
        }

        public static long? ToJavaScriptTicks(this DateTime? source)
        {
            if (source == null)
            {
                return null;
            }

            return ToJavaScriptTicks(source.Value);
        }
    }
}