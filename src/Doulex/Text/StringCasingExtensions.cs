using System.Text.RegularExpressions;

namespace Doulex.Text
{
    public static class StringCasingExtensions
    {
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

        public static string ToCamelCase(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            string result = value.ToPascalCase();
            result = Regex.Replace(result, @"^[A-Z]", m => m.Value.ToLowerInvariant());

            return result;
        }

        public static string ToPascalCase(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            string result = value.ExpandToSentenceCase(true);
            result = result.Replace(" ", string.Empty);

            return result;
        }

        public static string ToSnakeCase(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            string result = value.ExpandToSentenceCase();
            result = result.Replace(" ", "_").ToLowerInvariant();

            return result;
        }

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
