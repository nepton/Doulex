namespace Doulex;

/// <summary>
/// Provides a set of static methods for nullable types.
/// </summary>
public static class NullableExtensions
{
    /// <summary>
    /// Call the specified function with the value of the nullable if it has a value, otherwise return null.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="func">Callback when not null</param>
    /// <returns></returns>
    public static T? WhenNotNull<T>(this T? value, Func<T, T?> func) where T : struct
    {
        return value.HasValue ? func(value.Value) : value;
    }
}
