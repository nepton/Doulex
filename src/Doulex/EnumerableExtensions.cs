namespace Doulex;

/// <summary>
/// The extension methods for enumerable
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Return null if the enumerable is empty
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T>? ToNullIfEmpty<T>(this IEnumerable<T> source)
    {
        var enumerable = source as T[] ?? source.ToArray();
        if (!enumerable.Any())
        {
            return null;
        }

        return enumerable;
    }
}
