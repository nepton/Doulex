namespace Doulex
{
    /// <summary>
    /// The extension of string
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Trim all '\0' to empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimNull(this string str)
        {
            return str.Replace("\0", "");
        }

        /// <summary>
        /// 检查是否有效文件名
        /// </summary>
        /// <param name="str"></param>
        /// <returns>True 有效</returns>
        public static bool IsFileName(this string str)
        {
            char[] ivn = Path.GetInvalidFileNameChars();
            foreach (char x in ivn)
            {
                if (str.Contains(x))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 如果字符串为null or empty, 返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string DefaultIfNullOrEmpty(this string? source, string defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            return source!;
        }

        /// <summary>
        /// 把字符串的 empty 替换为 null
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string? ReplaceEmptyToNull(this string? source)
        {
            if (string.IsNullOrEmpty(source))
                return null;

            return source;
        }

        /// <summary>
        /// Indicate that the source is null or empty string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string? source)
        {
            return string.IsNullOrEmpty(source);
        }
    }
}
