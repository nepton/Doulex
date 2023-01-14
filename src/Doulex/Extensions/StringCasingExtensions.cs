using System.Text.RegularExpressions;

namespace Doulex
{
    /// <summary>
    /// The extension methods for the String class.
    /// </summary>
    public static class StringCasingExtensions
    {
        /// <summary>
        /// Converts the string to the sentence case.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="upperFirstLetter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ExpandToSentenceCase(this string value, bool upperFirstLetter = false)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            string result = value;

            result = result.Replace("-", " ").Replace("_", " ");
            result = Regex.Replace(result, "[A-Z]{2,}", m => m.Value.ToLower());

            result = Regex.Replace(result, @"([a-z][A-Z])", m => $"{m.Value[0]} {m.Value[1]}");
            result = Regex.Replace(result, @"\W[A-Z]",      m => m.Value.ToLower());
            result = Regex.Replace(result, @"^[a-z]",       m => m.Value.ToUpper());

            if (upperFirstLetter)
                result = Regex.Replace(result, @"\W[a-z]", m => m.Value.ToUpper());

            return result;
        }

        /// <summary>
        /// Convert the string to the camel case.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToCamelCase(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            string result = value.ToPascalCase();
            result = Regex.Replace(result, @"^[A-Z]", m => m.Value.ToLowerInvariant());

            return result;
        }

        /// <summary>
        /// Convert the string to the pascal case.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToPascalCase(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            string result = value.ExpandToSentenceCase(true);
            result = result.Replace(" ", string.Empty);

            return result;
        }

        /// <summary>
        /// Convert the string to the snake case.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToSnakeCase(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            string result = value.ExpandToSentenceCase();
            result = result.Replace(" ", "_").ToLowerInvariant();

            return result;
        }

        /// <summary>
        /// Convert the string to the kebab case.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToKebabCase(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            string result = value.ExpandToSentenceCase();
            result = result.Replace(" ", "-");

            return result.ToLower();
        }
    }
}
