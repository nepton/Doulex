namespace Doulex;

/// <summary>
/// The text of enum
/// </summary>
/// <example>
/// public enum Color
/// {
///     [EnumText("RED")]
///     Red,
/// }
///
/// Color.Red.Text();
/// </example>
[AttributeUsage(AttributeTargets.Field)]
public class EnumTextAttribute : Attribute
{
    /// <summary>
    /// The text of enum
    /// </summary>
    public string Text { get; }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="text"></param>
    public EnumTextAttribute(string text)
    {
        Text = text;
    }
}
