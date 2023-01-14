namespace Doulex
{
    /// <summary>
    /// The extension of float 
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// Check if the float is between two values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static bool AlmostEqual(this float a, float? b, float epsilon = 0.0000001f)
        {
            if (b is null)
                return Equals(a, b);

            return Math.Abs(a - b.Value) < epsilon;
        }

        /// <summary>
        /// Check if the float is between two values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static bool AlmostEqual(this float? a, float? b, float epsilon = 0.0000001f)
        {
            if (b is null || a is null)
                return Equals(a, b);

            return Math.Abs(a.Value - b.Value) < epsilon;
        }

        /// <summary>
        /// If it is NaN, replace it with the default value
        /// </summary>
        /// <param name="source"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static float ReplaceIfNaN(this float source, float newValue)
        {
            if (float.IsNaN(source))
                return newValue;

            return source;
        }

        /// <summary>
        /// Limits the value to the specified output range
        /// </summary>
        /// <param name="source"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static float Clamp(this float source, float minimum, float maximum)
        {
#if NETSTANDARD2_1_OR_GREATER
            return Math.Clamp(source, minimum, maximum);
#else
            return Math.Max(minimum, Math.Min(maximum, source));
#endif
        }

        /// <summary>
        /// Return a string describing the value as a file size.
        /// For example, 1.2M
        /// </summary>
        /// <param name="value"></param>
        /// <param name="digits">Decimal places</param>
        /// <param name="minimumFolds">The unit index of the smallest number that is allowed to be folded, e.g. -2 if you want to fold to micro, enter 1 if you want to fold to K</param>
        /// <param name="maximumFolds">The unit index of the largest number that is allowed to be folded, e.g. -2 if you want to fold to micro, 1 if you want to fold to K</param>
        /// <returns></returns>
        public static string ToZippedString(this float value, int? digits = null, int? minimumFolds = null, int? maximumFolds = null)
        {
            return DoubleExtensions.ToZippedString(value, digits, minimumFolds, maximumFolds);
        }
    }
}

// create unit test for floatExtensions
