namespace Hertz
{
    /// <summary>
    /// The extension for task
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Make the task object not null. We use it for await keyword
        /// Eg: await (Obj?.MethodAsync()).ForAwait();
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Task ForAwait(this Task? source)
        {
            return source ?? Task.CompletedTask;
        }

        /// <summary>
        /// Make the task object not null. We use it for await keyword
        /// Eg: await (Obj?.MethodAsync()).ForAwait();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Task<T?> ForAwait<T>(this Task<T?>? source)
        {
            return source ?? Task.FromResult<T?>(default);
        }
    }
}
