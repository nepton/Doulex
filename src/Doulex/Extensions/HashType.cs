using Doulex;

/// <summary>
/// The type of hash
/// </summary>
public enum HashType
{
    /// <summary>
    /// MD5
    /// </summary>
    [EnumText("MD5")] MD5,

    /// <summary>
    /// SHA1
    /// </summary>
    [EnumText("SHA1")] SHA1,

    /// <summary>
    /// SHA256
    /// </summary>
    [EnumText("SHA256")] SHA256,

    /// <summary>
    /// SHA384
    /// </summary>
    [EnumText("SHA384")] SHA384,

    /// <summary>
    /// SHA512
    /// </summary>
    [EnumText("SHA512")] SHA512,
}
