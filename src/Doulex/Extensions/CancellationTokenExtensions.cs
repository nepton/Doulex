namespace Doulex;

/// <summary>
/// The extension of CancellationToken
/// </summary>
public static class CancellationTokenExtensions
{
    /// <summary>
    /// Add timeout to the cancellation token
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public static CancellationToken AddTimeout(this CancellationToken cancellationToken, TimeSpan timeout)
    {
        if (timeout < TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(timeout), timeout, "Timeout must be greater than or equal to zero.");

        if (timeout == TimeSpan.Zero)
            return cancellationToken;

        var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cts.CancelAfter(timeout);
        return cts.Token;
    }
}
