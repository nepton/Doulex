namespace Doulex.Text
{
    /// <summary>
    /// converts a string to the format that you want
    /// </summary>
    public static class CasingConverter
    {
        /// <summary>
        /// Converts a string to the format that you want
        /// </summary>
        /// <param name="source"></param>
        /// <param name="targetStyle"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string Convert(string source, CasingStyle targetStyle)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return targetStyle switch
            {
                CasingStyle.None     => source,
                CasingStyle.Sentence => source.ExpandToSentenceCase(),
                CasingStyle.Camel    => source.ToCamelCase(),
                CasingStyle.Pascal   => source.ToPascalCase(),
                CasingStyle.Snake    => source.ToSnakeCase(),
                CasingStyle.Kebab    => source.ToKebabCase(),
                _                    => throw new ArgumentOutOfRangeException(nameof(targetStyle))
            };
        }
    }
}
