namespace Doulex;

/// <summary>
/// Extension for guid 
/// </summary>
public static class GuidExtensions
{
    /// <summary>
    /// Two guid take Xor
    /// </summary>
    /// <param name="source"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static Guid Xor(this Guid source, Guid other)
    {
        var bytes      = source.ToByteArray();
        var otherBytes = other.ToByteArray();
        for (var i = 0; i < bytes.Length; i++)
        {
            bytes[i] ^= otherBytes[i];
        }

        return new Guid(bytes);
    }
}
