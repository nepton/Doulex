namespace Doulex.Types;

/// <summary>
/// The extension of generic type
/// </summary>
public static class GenericTypeExtensions
{
    /// <summary>
    /// Get the name of generic type
    /// the format of result like this <![CDATA[Test<int,string>]]>
    /// </summary>
    /// <param name="type"></param>
    /// <returns>Return the type of generic type</returns>
    public static string GetGenericTypeName(this Type type)
    {
        string typeName;

        if (type.IsGenericType)
        {
            var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());
            typeName = $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
        }
        else
        {
            typeName = type.Name;
        }

        return typeName;
    }

    public static string GetGenericTypeName(this object @object)
    {
        return @object.GetType().GetGenericTypeName();
    }
}
