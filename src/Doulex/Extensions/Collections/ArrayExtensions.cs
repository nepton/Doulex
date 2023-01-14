namespace Doulex;

/// <summary>
/// The extension methods for enumerable
/// </summary>
public static class ArrayExtensions
{
    /// <summary>
    /// Return null if the enumerable is empty
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T[]? ToNullIfEmpty<T>(this T[] source)
    {
        return source.Any() ? source : null;
    }
}
