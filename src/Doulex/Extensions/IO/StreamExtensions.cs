namespace Doulex;

/// <summary>
/// The extensions for <see cref="Stream"/>
/// </summary>
public static class StreamExtensions
{
    /// <summary>
    /// Read all bytes from the stream
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static async Task<byte[]> ReadAllBytesAsync(this Stream stream)
    {
        if (stream == null)
            throw new ArgumentNullException(nameof(stream));

        if (!stream.CanRead)
            throw new ArgumentException("The stream is not readable.", nameof(stream));

        if (stream is MemoryStream memoryStream)
            return memoryStream.ToArray();

        if (stream.Length == 0)
            return Array.Empty<byte>();

        var buffer   = new byte[stream.Length];
        var position = 0;
        while (position < buffer.Length)
        {
            var read = await stream.ReadAsync(buffer, position, buffer.Length - position);

            if (read == 0)
                break;

            position += read;
        }

        return buffer;
    }

    /// <summary>
    /// Read all bytes from the stream
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static byte[] ReadAllBytes(this Stream stream)
    {
        if (stream == null)
            throw new ArgumentNullException(nameof(stream));

        if (!stream.CanRead)
            throw new ArgumentException("The stream is not readable.", nameof(stream));

        if (stream is MemoryStream memoryStream)
            return memoryStream.ToArray();

        if (stream.Length == 0)
            return Array.Empty<byte>();

        var buffer   = new byte[stream.Length];
        var position = 0;
        while (position < buffer.Length)
        {
            var read = stream.Read(buffer, position, buffer.Length - position);

            if (read == 0)
                break;

            position += read;
        }

        return buffer;
    }
}
