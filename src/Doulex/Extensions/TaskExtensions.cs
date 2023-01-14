namespace Doulex
{
    /// <summary>
    /// The extension for task
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// 实现任务执行即忘记的模式, 无需关心任务后续的执行情况
        /// </summary>
        /// <param name="task"></param>
        public static void Forget(this Task task)
        {
            if (!task.IsCompleted || task.IsFaulted)
            {
                _ = ForgetAwaited(task);
            }
        }

        private static async Task ForgetAwaited(Task task)
        {
            try
            {
                await task;
            }
            catch
            {
                // Nothing to do here
            }
        }

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
