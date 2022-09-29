using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Hertz.Linq
{
    /// <summary>
    /// 异步可查询扩展
    /// </summary>
    public static class AsyncQueryableExtensions
    {
        /// <summary>
        /// 默认的方法提供对象
        /// </summary>
        private static readonly IAsyncQueryableMethodsProvider _default = new AsyncToSyncQueryableProvider();

        /// <summary>
        /// 异步查询方法 Provider
        /// </summary>
        private static readonly ConcurrentDictionary<Type, IAsyncQueryableMethodsProvider> _providers = new ConcurrentDictionary<Type, IAsyncQueryableMethodsProvider>();

        /// <summary>
        /// 注册 Provider
        /// </summary>
        /// <param name="asyncQueryableMethodsProvider">注册异步查询方法</param>
        public static void RegisterAsyncQueryableMethodsProvider(IAsyncQueryableMethodsProvider asyncQueryableMethodsProvider)
        {
            if (asyncQueryableMethodsProvider == null)
                throw new ArgumentNullException(nameof(asyncQueryableMethodsProvider));

            _providers.TryAdd(asyncQueryableMethodsProvider.QueryProvider, asyncQueryableMethodsProvider);
        }

        /// <summary>
        /// 方法包（默认返回同步版本）
        /// </summary>
        private static IAsyncQueryableMethodsProvider GetProviderOrDefault(IQueryable queryable)
        {
            var providerType = queryable.Provider.GetType();
            if (_providers.TryGetValue(providerType, out var provider))
                return provider;

            return _default;
        }

        /// <summary>
        /// Asynchronously determines whether a sequence contains any elements.
        /// </summary>
        public static Task<bool> AnyAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).AnyAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously determines whether any element of a sequence satisfies a condition.
        /// </summary>
        public static Task<bool> AnyAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).AnyAsync(source, predicate, cancellationToken);
        }

        /// <summary>
        /// Asynchronously determines whether all the elements of a sequence satisfy a condition.
        /// </summary>
        public static Task<bool> AllAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).AllAsync(source, predicate, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the number of elements in a sequence.
        /// </summary>
        public static Task<int> CountAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).CountAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the number of elements in a sequence that satisfy a condition.
        /// </summary>
        public static Task<int> CountAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).CountAsync(source, predicate, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns an <see cref="T:System.Int64" /> that represents the total number of elements in a sequence.
        /// </summary>
        public static Task<long> LongCountAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).LongCountAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns an <see cref="T:System.Int64" /> that represents the number of elements in a sequence that satisfy a condition.
        /// </summary>
        public static Task<long> LongCountAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).LongCountAsync(source, predicate, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the first element of a sequence.
        /// </summary>
        public static Task<TSource> FirstAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).FirstAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the first element of a sequence that satisfies a specified condition.
        /// </summary>
        public static Task<TSource> FirstAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).FirstAsync(source, predicate, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        public static Task<TSource?> FirstOrDefaultAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).FirstOrDefaultAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the first element of a sequence that satisfies a specified condition or a default value if no such element is found.
        /// </summary>
        public static Task<TSource?> FirstOrDefaultAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).FirstOrDefaultAsync(source, predicate, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the last element of a sequence.
        /// </summary>
        public static Task<TSource> LastAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).LastAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the last element of a sequence that satisfies a specified condition.
        /// </summary>
        public static Task<TSource> LastAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).LastAsync(source, predicate, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the last element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        public static Task<TSource?> LastOrDefaultAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).LastOrDefaultAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the last element of a sequence that satisfies a specified condition or a default value if no such element is found.
        /// </summary>
        public static Task<TSource?> LastOrDefaultAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).LastOrDefaultAsync(source, predicate, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>
        public static Task<TSource> SingleAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).SingleAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
        /// </summary>
        public static Task<TSource> SingleAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).SingleAsync(source, predicate, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the only element of a sequence, or a default value if the sequence is empty; this method throws an exception if there is more than one element in the sequence.
        /// </summary>
        public static Task<TSource?> SingleOrDefaultAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).SingleOrDefaultAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the only element of a sequence that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
        /// </summary>
        public static Task<TSource?> SingleOrDefaultAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).SingleOrDefaultAsync(source, predicate, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the minimum value of a sequence.
        /// </summary>
        public static Task<TSource?> MinAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).MinAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes a projection function on each element of a sequence and returns the minimum resulting value.
        /// </summary>
        public static Task<TResult?> MinAsync<TSource, TResult>(
            this IQueryable<TSource>           source,
            Expression<Func<TSource, TResult>> selector,
            CancellationToken                  cancellationToken = default)
        {
            return GetProviderOrDefault(source).MinAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously returns the maximum value of a sequence.
        /// </summary>
        public static Task<TSource?> MaxAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).MaxAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes a projection function on each element of a sequence and returns the maximum resulting value.
        /// </summary>
        public static Task<TResult?> MaxAsync<TSource, TResult>(
            this IQueryable<TSource>           source,
            Expression<Func<TSource, TResult>> selector,
            CancellationToken                  cancellationToken = default)
        {
            return GetProviderOrDefault(source).MaxAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public static Task<decimal> SumAsync(
            this IQueryable<decimal> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public static Task<decimal?> SumAsync(
            this IQueryable<decimal?> source,
            CancellationToken         cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<decimal> SumAsync<TSource>(
            this IQueryable<TSource>           source,
            Expression<Func<TSource, decimal>> selector,
            CancellationToken                  cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<decimal?> SumAsync<TSource>(
            this IQueryable<TSource>            source,
            Expression<Func<TSource, decimal?>> selector,
            CancellationToken                   cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public static Task<int> SumAsync(
            this IQueryable<int> source,
            CancellationToken    cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public static Task<int?> SumAsync(
            this IQueryable<int?> source,
            CancellationToken     cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<int> SumAsync<TSource>(
            this IQueryable<TSource>       source,
            Expression<Func<TSource, int>> selector,
            CancellationToken              cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<int?> SumAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, int?>> selector,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public static Task<long> SumAsync(
            this IQueryable<long> source,
            CancellationToken     cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public static Task<long?> SumAsync(
            this IQueryable<long?> source,
            CancellationToken      cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<long> SumAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, long>> selector,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<long?> SumAsync<TSource>(
            this IQueryable<TSource>         source,
            Expression<Func<TSource, long?>> selector,
            CancellationToken                cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public static Task<double> SumAsync(
            this IQueryable<double> source,
            CancellationToken       cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public static Task<double?> SumAsync(
            this IQueryable<double?> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<double> SumAsync<TSource>(
            this IQueryable<TSource>          source,
            Expression<Func<TSource, double>> selector,
            CancellationToken                 cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<double?> SumAsync<TSource>(
            this IQueryable<TSource>           source,
            Expression<Func<TSource, double?>> selector,
            CancellationToken                  cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public static Task<float> SumAsync(
            this IQueryable<float> source,
            CancellationToken      cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public static Task<float?> SumAsync(
            this IQueryable<float?> source,
            CancellationToken       cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<float> SumAsync<TSource>(
            this IQueryable<TSource>         source,
            Expression<Func<TSource, float>> selector,
            CancellationToken                cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<float?> SumAsync<TSource>(
            this IQueryable<TSource>          source,
            Expression<Func<TSource, float?>> selector,
            CancellationToken                 cancellationToken = default)
        {
            return GetProviderOrDefault(source).SumAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public static Task<decimal> AverageAsync(
            this IQueryable<decimal> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public static Task<decimal?> AverageAsync(
            this IQueryable<decimal?> source,
            CancellationToken         cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<decimal> AverageAsync<TSource>(
            this IQueryable<TSource>           source,
            Expression<Func<TSource, decimal>> selector,
            CancellationToken                  cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<decimal?> AverageAsync<TSource>(
            this IQueryable<TSource>            source,
            Expression<Func<TSource, decimal?>> selector,
            CancellationToken                   cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public static Task<double> AverageAsync(
            this IQueryable<int> source,
            CancellationToken    cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public static Task<double?> AverageAsync(
            this IQueryable<int?> source,
            CancellationToken     cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<double> AverageAsync<TSource>(
            this IQueryable<TSource>       source,
            Expression<Func<TSource, int>> selector,
            CancellationToken              cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<double?> AverageAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, int?>> selector,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public static Task<double> AverageAsync(
            this IQueryable<long> source,
            CancellationToken     cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public static Task<double?> AverageAsync(
            this IQueryable<long?> source,
            CancellationToken      cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<double> AverageAsync<TSource>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, long>> selector,
            CancellationToken               cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source,
                selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<double?> AverageAsync<TSource>(
            this IQueryable<TSource>         source,
            Expression<Func<TSource, long?>> selector,
            CancellationToken                cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public static Task<double> AverageAsync(
            this IQueryable<double> source,
            CancellationToken       cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public static Task<double?> AverageAsync(
            this IQueryable<double?> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<double> AverageAsync<TSource>(
            this IQueryable<TSource>          source,
            Expression<Func<TSource, double>> selector,
            CancellationToken                 cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source,
                selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<double?> AverageAsync<TSource>(
            this IQueryable<TSource>           source,
            Expression<Func<TSource, double?>> selector,
            CancellationToken                  cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source,
                selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public static Task<float> AverageAsync(
            this IQueryable<float> source,
            CancellationToken      cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public static Task<float?> AverageAsync(
            this IQueryable<float?> source,
            CancellationToken       cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<float> AverageAsync<TSource>(
            this IQueryable<TSource>         source,
            Expression<Func<TSource, float>> selector,
            CancellationToken                cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public static Task<float?> AverageAsync<TSource>(
            this IQueryable<TSource>          source,
            Expression<Func<TSource, float?>> selector,
            CancellationToken                 cancellationToken = default)
        {
            return GetProviderOrDefault(source).AverageAsync(source, selector, cancellationToken);
        }

        /// <summary>
        /// Asynchronously determines whether a sequence contains a specified element by using the default equality comparer.
        /// </summary>
        public static Task<bool> ContainsAsync<TSource>(
            this IQueryable<TSource> source,
            TSource                  item,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).ContainsAsync(source, item, cancellationToken);
        }

        /// <summary>
        /// Asynchronously creates a list from an IQueryable by enumerating it asynchronously.
        /// </summary>
        public static Task<List<TSource>> ToListAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).ToListAsync(source, cancellationToken);
        }

        /// <summary>
        /// Asynchronously creates an array from an IQueryable by enumerating it asynchronously.
        /// </summary>
        public static Task<TSource[]> ToArrayAsync<TSource>(
            this IQueryable<TSource> source,
            CancellationToken        cancellationToken = default)
        {
            return GetProviderOrDefault(source).ToArrayAsync(source, cancellationToken);
        }


        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector function.
        /// </summary>
        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(
            this IQueryable<TSource> source,
            Func<TSource, TKey>      keySelector,
            CancellationToken        cancellationToken = default) where TKey : notnull
        {
            return GetProviderOrDefault(source).ToDictionaryAsync(source, keySelector, cancellationToken);
        }

        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector function and a comparer.
        /// </summary>
        public static Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(
            this IQueryable<TSource> source,
            Func<TSource, TKey>      keySelector,
            IEqualityComparer<TKey>  comparer,
            CancellationToken        cancellationToken = default) where TKey : notnull
        {
            return GetProviderOrDefault(source).ToDictionaryAsync(source, keySelector, comparer, cancellationToken);
        }

        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector and an element selector function.
        /// </summary>
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(
            this IQueryable<TSource> source,
            Func<TSource, TKey>      keySelector,
            Func<TSource, TElement>  elementSelector,
            CancellationToken        cancellationToken = default) where TKey : notnull
        {
            return GetProviderOrDefault(source).ToDictionaryAsync(source, keySelector, elementSelector, cancellationToken);
        }

        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector function, a comparer, and an element selector function.
        /// </summary>
        public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(
            this IQueryable<TSource> source,
            Func<TSource, TKey>      keySelector,
            Func<TSource, TElement>  elementSelector,
            IEqualityComparer<TKey>  comparer,
            CancellationToken        cancellationToken = default) where TKey : notnull
        {
            return GetProviderOrDefault(source).ToDictionaryAsync(source, keySelector, elementSelector, comparer, cancellationToken);
        }
    }
}