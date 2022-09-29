namespace Hertz
{
    /// <summary>
    /// bytes 扩展方法
    /// </summary>
    public static class BytesExtensions
    {
        /// <summary>
        /// 把 byte[] 转换为 string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string? ToHexString(this byte[]? source)
        {
            return source == null ? null : string.Join(" ", source.Select(c => $"{c:x2}"));
        }
    }
}
