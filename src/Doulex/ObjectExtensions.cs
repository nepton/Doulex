using System.Dynamic;

namespace Doulex;

/// <summary>
/// The extension methods for the <see cref="object"/> class.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Change an object to dynamic and remove the null attribute
    /// </summary>
    /// <param name="obj">The object will be handled</param>
    /// <param name="excepts">The property name of excepts</param>
    /// <returns>Return a dynamic object does not include the null value property </returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static dynamic RemoveNullProperty(this object obj, params string[] excepts)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        dynamic expando    = new ExpandoObject();
        var     properties = obj.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(obj);
            if (value != null || excepts.Contains(property.Name))
            {
                ((IDictionary<string, object?>) expando).Add(property.Name, value);
            }
        }

        return expando;
    }
    
    /// <summary>
    /// Convert a object to a dictionary
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IDictionary<string, object?> ToDictionary(this object obj)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        var properties = obj.GetType().GetProperties();
        var dictionary = new Dictionary<string, object?>();
        foreach (var property in properties)
        {
            var value = property.GetValue(obj);
            dictionary.Add(property.Name, value);
        }

        return dictionary;
    }
}
