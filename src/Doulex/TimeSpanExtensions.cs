namespace Doulex
{
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// 把时间间隔转换为中文描述
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToSummaryString(this TimeSpan source)
        {
            if (source.TotalDays is >= 1 or <= -1)
                return $"{source.TotalDays:F0} 天";

            if (source.TotalHours is >= 1 or <= -1)
                return $"{source.TotalHours:F0} 小时";

            if (source.TotalMinutes is >= 1 or <= -1)
                return $"{source.TotalMinutes:F0} 分钟";

            if (source.TotalSeconds is >= 1 or <= -1)
                return $"{source.TotalSeconds:F0} 秒";

            return $"{source.TotalMilliseconds:F0} 毫秒";
        }
    }
}
