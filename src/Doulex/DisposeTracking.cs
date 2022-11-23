namespace Doulex;

/// <summary>
/// Tracking a object until to be disposed.
/// </summary>
/// <typeparam name="T"></typeparam>
public class DisposeTracking<T> :
#if NETSTANDARD2_1
    IAsyncDisposable,
#endif
    IDisposable
    where T : notnull
{
    private readonly Func<Task> _disposeCallback;

    private bool _disposed;

    /// <summary>
    /// The object to be tracked.
    /// </summary>
    public T Target { get; }

    /// <summary>
    /// Indicates whether the object has been disposed.
    /// </summary>
    public bool IsDisposed => _disposed;

    /// <summary>
    /// Create a new instance of <see cref="DisposeTracking{T}"/>.
    /// </summary>
    /// <param name="target">The object that will be tracked</param>
    /// <param name="disposeCallback">The callback when disposing</param>
    public DisposeTracking(T target, Action disposeCallback)
    {
        if (disposeCallback == null) throw new ArgumentNullException(nameof(disposeCallback));
        
        _disposeCallback = delegate
        {
            disposeCallback();
            return Task.CompletedTask;
        };
        Target = target ?? throw new ArgumentNullException(nameof(target));
    }

    /// <summary>
    /// Create a new instance of <see cref="DisposeTracking{T}"/>.
    /// </summary>
    /// <param name="target">The object that will be tracked</param>
    /// <param name="disposeCallback">The callback when disposing</param>
    public DisposeTracking(T target, Func<Task> disposeCallback)
    {
        _disposeCallback = disposeCallback ?? throw new ArgumentNullException(nameof(disposeCallback));
        Target           = target ?? throw new ArgumentNullException(nameof(target));
    }

    /// <summary>
    /// Implicit conversion to the object to be tracked.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static implicit operator T(DisposeTracking<T> obj) => obj.Target;

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return $"* {Target.ToString()}";
    }

#if NETSTANDARD2_1_OR_GREATER
    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.</summary>
    /// <returns>A task that represents the asynchronous dispose operation.</returns>
    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        await _disposeCallback();
        _disposed = true;
    }
#endif

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposeCallback().GetAwaiter().GetResult();
        _disposed = true;
    }
}
