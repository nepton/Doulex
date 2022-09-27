namespace Doulex.Toolkit.Text;

public static class CasingConverter
{
    public static string Convert(string source, CasingStyle targetStyle)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        return targetStyle switch
        {
            CasingStyle.None => source,
            CasingStyle.Sentence => source.ExpandToSentenceCase(),
            CasingStyle.Camel => source.ToCamelCase(),
            CasingStyle.Pascal => source.ToPascalCase(),
            CasingStyle.Snake => source.ToSnakeCase(),
            CasingStyle.Kebab => source.ToKebabCase(),
            _ => throw new ArgumentOutOfRangeException(nameof(targetStyle))
        };
    }
}
