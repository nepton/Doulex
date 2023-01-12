namespace Doulex
{
    /// <summary>
    /// The extension of decimal 
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// Limits the value to the specified output range
        /// </summary>
        /// <param name="source"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static decimal Clamp(this decimal source, decimal minimum, decimal maximum)
        {
#if NETSTANDARD2_1_OR_GREATER
            return Math.Clamp(source, minimum, maximum);
#else
            return Math.Max(minimum, Math.Min(maximum, source));
#endif
        }

        /// <summary>
        /// Returns the value of the specified number rounded to the nearest value that is a multiple of the specified factor.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal Round(this decimal source, int digits)
        {
            return Math.Round(source, digits);
        }

        /// <summary>
        /// Return a string describing the value as a file size.
        /// For example, 1.2M
        /// </summary>
        /// <param name="value"></param>
        /// <param name="digits">小数位数</param>
        /// <param name="minimumFolds">允许折叠的最小数字的单位索引, 例如要折叠到微, 则输入-2, 要折叠到K, 则输入1</param>
        /// <param name="maximumFolds">允许折叠的最大数字的单位索引, 例如要折叠到微, 则输入-2, 要折叠到K, 则输入1</param>
        /// <returns></returns>
        public static string ToZippedString(this decimal value, int? digits = null, int? minimumFolds = null, int? maximumFolds = null)
        {
            return ((double) value).ToZippedString(digits, minimumFolds, maximumFolds);
        }
    }
}
