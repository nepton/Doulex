using System.Diagnostics.CodeAnalysis;

namespace Doulex;

/// <summary>
/// Enumerable extensions
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Check the collection is null or empty.
    /// </summary>
    /// <typeparam name="T">The type of the collection.</typeparam>
    /// <param name="enumerable">The collection to check.</param>
    /// <returns>True if collection is null or empty, false otherwise.</returns>
#if NETSTANDARD2_1_OR_GREATER
    public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? enumerable) => enumerable == null || !enumerable.Any();
#else
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable) => enumerable == null || !enumerable.Any();
#endif
}
