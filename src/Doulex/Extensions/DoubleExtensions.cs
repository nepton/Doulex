﻿namespace Doulex
{
    /// <summary>
    /// The extension of double 
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Check if the double is between two values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static bool AlmostEqual(this double a, double? b, double epsilon = 0.0000001)
        {
            if (b == null)
                return Equals(a, b);

            return Math.Abs(a - b.Value) < epsilon;
        }

        /// <summary>
        /// Check if the double is between two values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static bool AlmostEqual(this double? a, double? b, double epsilon = 0.0000001)
        {
            if (a == null || b == null)
                return Equals(a, b);

            return Math.Abs(a.Value - b.Value) < epsilon;
        }

        /// <summary>
        /// If it is NaN, replace it with the default value
        /// </summary>
        /// <param name="source"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static double ReplaceIfNaN(this double source, double newValue)
        {
            if (double.IsNaN(source))
                return newValue;

            return source;
        }

        /// <summary>
        /// If it is NaN, replace it with null
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double? ReplaceToNullIfNaN(this double source)
        {
            if (double.IsNaN(source))
                return null;

            return source;
        }

        /// <summary>
        /// Limits the value to the specified output range
        /// </summary>
        /// <param name="source"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static double Clamp(this double source, double minimum, double maximum)
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
        public static double Round(this double source, int digits)
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
        public static string ToZippedString(this double value, int? digits = null, int? minimumFolds = null, int? maximumFolds = null)
        {
            string[] greatThanOne = {"", "k", "M", "G", "T", "P", "E", "Z", "Y"};
            string[] lessThanOne  = {"", "m", "u", "n", "p", "f", "a", "z", "y"};

            // 设置限制值的范围, 例如限制了转换值 1e6 -- 1e12 则从 M -- T 之间转换
            var minIndex = minimumFolds ?? int.MinValue;
            var maxIndex = maximumFolds ?? int.MaxValue;

            if (minIndex > maxIndex)
                (minIndex, maxIndex) = (maxIndex, minIndex);

            minIndex = Math.Max(-lessThanOne.Length + 1, Math.Min(greatThanOne.Length - 1, minIndex));
            maxIndex = Math.Max(-lessThanOne.Length + 1, Math.Min(greatThanOne.Length - 1, maxIndex));

            // 计算幂
            var index = (int) Math.Floor(Math.Log10(Math.Abs(value)) / 3);
            index = Math.Max(minIndex, Math.Min(maxIndex, index));
            var power = index * 3;

            // compute the value
            var adjustValue = value / Math.Pow(10, power);

            // 生成结果  23.6 K
            digits ??= Math.Min(10, Math.Max(0, 2 - (int) Math.Log10(Math.Abs(adjustValue))));
            var unit  = index >= 0 ? greatThanOne[index] : lessThanOne[-index];
            var round = Math.Round(adjustValue, digits.Value, MidpointRounding.AwayFromZero);

            return $"{round}{unit}";
        }
    }
}
