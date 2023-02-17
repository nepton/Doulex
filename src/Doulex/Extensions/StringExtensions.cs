using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

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
        public static bool IsNullOrEmpty(
#if NETSTANDARD2_1_OR_GREATER
            [NotNullWhen(false)]
#endif
            this string? source
        )
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// Convert string to hash guid
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Guid ToHashedGuid(this string source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            using var calc = MD5.Create();
            var       hash = calc.ComputeHash(Encoding.UTF8.GetBytes(source));
            return new Guid(hash);
        }

        /// <summary>
        /// Convert string to guid
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string source)
        {
            return new Guid(source);
        }

        /// <summary>
        /// Convert string to base64 string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToBase64(this string source)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(source));
        }

        /// <summary>
        /// Convert base64 string to string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FromBase64(this string source)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(source));
        }
    }
}
