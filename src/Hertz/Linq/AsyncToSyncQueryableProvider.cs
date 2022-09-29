using System.Linq.Expressions;

// 不可通过扩展调用方法实现，编译器可能产生无穷递归
// ReSharper disable InvokeAsExtensionMethod

namespace Hertz.Linq
{
    /// <summary>
    /// 默认的异步查询。如果没有实现，则使用同步查询版替代
    /// </summary>
    public class AsyncToSyncQueryableProvider : IAsyncQueryableMethodsProvider
    {
        /// <summary>
        /// Asynchronously determines whether a sequence contains any elements.
        /// </summary>
        public Task<bool> AnyAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.Any(source));
        }

        /// <summary>
        /// Asynchronously determines whether any element of a sequence satisfies a condition.
        /// </summary>
        public Task<bool> AnyAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.Any(source, predicate));
        }

        /// <summary>
        /// Asynchronously determines whether all the elements of a sequence satisfy a condition.
        /// </summary>
        public Task<bool> AllAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.All(source, predicate));
        }

        /// <summary>
        /// Asynchronously returns the number of elements in a sequence.
        /// </summary>
        public Task<int> CountAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.Count(source));
        }

        /// <summary>
        /// Asynchronously returns the number of elements in a sequence that satisfy a condition.
        /// </summary>
        public Task<int> CountAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.Count(source, predicate));
        }

        /// <summary>
        /// Asynchronously returns an <see cref="T:System.Int64" /> that represents the total number of elements in a sequence.
        /// </summary>
        public Task<long> LongCountAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.LongCount(source));
        }

        /// <summary>
        /// Asynchronously returns an <see cref="T:System.Int64" /> that represents the number of elements in a sequence that satisfy a condition.
        /// </summary>
        public Task<long> LongCountAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.LongCount(source, predicate));
        }

        /// <summary>
        /// Asynchronously returns the first element of a sequence.
        /// </summary>
        public Task<TSource> FirstAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.First(source));
        }

        /// <summary>
        /// Asynchronously returns the first element of a sequence that satisfies a specified condition.
        /// </summary>
        public Task<TSource> FirstAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.First(source, predicate));
        }

        /// <summary>
        /// Asynchronously returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        public Task<TSource?> FirstOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.FirstOrDefault(source));
        }

        /// <summary>
        /// Asynchronously returns the first element of a sequence that satisfies a specified condition or a default value if no such element is found.
        /// </summary>
        public Task<TSource?> FirstOrDefaultAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.FirstOrDefault(source, predicate));
        }

        /// <summary>
        /// Asynchronously returns the last element of a sequence.
        /// </summary>
        public Task<TSource> LastAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.Last(source));
        }

        /// <summary>
        /// Asynchronously returns the last element of a sequence that satisfies a specified condition.
        /// </summary>
        public Task<TSource> LastAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.Last(source, predicate));
        }

        /// <summary>
        /// Asynchronously returns the last element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        public Task<TSource?> LastOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.LastOrDefault(source));
        }

        /// <summary>
        /// Asynchronously returns the last element of a sequence that satisfies a specified condition or a default value if no such element is found.
        /// </summary>
        public Task<TSource?> LastOrDefaultAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.LastOrDefault(source, predicate));
        }

        /// <summary>
        /// Asynchronously returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>
        public Task<TSource> SingleAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.Single(source));
        }

        /// <summary>
        /// Asynchronously returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
        /// </summary>
        public Task<TSource> SingleAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.Single(source, predicate));
        }

        /// <summary>
        /// Asynchronously returns the only element of a sequence, or a default value if the sequence is empty; this method throws an exception if there is more than one element in the sequence.
        /// </summary>
        public Task<TSource?> SingleOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.SingleOrDefault(source));
        }

        /// <summary>
        /// Asynchronously returns the only element of a sequence that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
        /// </summary>
        public Task<TSource?> SingleOrDefaultAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.SingleOrDefault(source, predicate));
        }

        /// <summary>
        /// Asynchronously returns the minimum value of a sequence.
        /// </summary>
        public Task<TSource?> MinAsync<TSource>(IQueryable<TSource> source,
            CancellationToken                                       cancellationToken = default)
        {
            return Task.FromResult(Queryable.Min(source));
        }

        /// <summary>
        /// Asynchronously invokes a projection function on each element of a sequence and returns the minimum resulting value.
        /// </summary>
        public Task<TResult?> MinAsync<TSource, TResult>(IQueryable<TSource> source,
            Expression<Func<TSource, TResult>>                               selector,
            CancellationToken                                                cancellationToken = default)
        {
            return Task.FromResult(Queryable.Min(source, selector));
        }

        /// <summary>
        /// Asynchronously returns the maximum value of a sequence.
        /// </summary>
        public Task<TSource?> MaxAsync<TSource>(IQueryable<TSource> source,
            CancellationToken                                       cancellationToken = default)
        {
            return Task.FromResult(Queryable.Max(source));
        }

        /// <summary>
        /// Asynchronously invokes a projection function on each element of a sequence and returns the maximum resulting value.
        /// </summary>
        public Task<TResult?> MaxAsync<TSource, TResult>(IQueryable<TSource> source,
            Expression<Func<TSource, TResult>>                               selector,
            CancellationToken                                                cancellationToken = default)
        {
            return Task.FromResult(Queryable.Max(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public Task<decimal> SumAsync(
            IQueryable<decimal> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source));
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public Task<decimal?> SumAsync(
            IQueryable<decimal?> source,
            CancellationToken    cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source));
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<decimal> SumAsync<TSource>(
            IQueryable<TSource>                source,
            Expression<Func<TSource, decimal>> selector,
            CancellationToken                  cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<decimal?> SumAsync<TSource>(
            IQueryable<TSource>                 source,
            Expression<Func<TSource, decimal?>> selector,
            CancellationToken                   cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public Task<int> SumAsync(
            IQueryable<int>   source,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source));
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public Task<int?> SumAsync(
            IQueryable<int?>  source,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source));
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<int> SumAsync<TSource>(
            IQueryable<TSource>            source,
            Expression<Func<TSource, int>> selector,
            CancellationToken              cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<int?> SumAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, int?>> selector,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public Task<long> SumAsync(
            IQueryable<long>  source,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source));
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public Task<long?> SumAsync(
            IQueryable<long?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source));
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<long> SumAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, long>> selector,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<long?> SumAsync<TSource>(
            IQueryable<TSource>              source,
            Expression<Func<TSource, long?>> selector,
            CancellationToken                cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public Task<double> SumAsync(
            IQueryable<double> source,
            CancellationToken  cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source));
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public Task<double?> SumAsync(
            IQueryable<double?> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source));
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<double> SumAsync<TSource>(
            IQueryable<TSource>               source,
            Expression<Func<TSource, double>> selector,
            CancellationToken                 cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<double?> SumAsync<TSource>(
            IQueryable<TSource>                source,
            Expression<Func<TSource, double?>> selector,
            CancellationToken                  cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public Task<float> SumAsync(
            IQueryable<float> source,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source));
        }

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        public Task<float?> SumAsync(
            IQueryable<float?> source,
            CancellationToken  cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source));
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<float> SumAsync<TSource>(
            IQueryable<TSource>              source,
            Expression<Func<TSource, float>> selector,
            CancellationToken                cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<float?> SumAsync<TSource>(
            IQueryable<TSource>               source,
            Expression<Func<TSource, float?>> selector,
            CancellationToken                 cancellationToken = default)
        {
            return Task.FromResult(Queryable.Sum(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public Task<decimal> AverageAsync(
            IQueryable<decimal> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public Task<decimal?> AverageAsync(
            IQueryable<decimal?> source,
            CancellationToken    cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<decimal> AverageAsync<TSource>(
            IQueryable<TSource>                source,
            Expression<Func<TSource, decimal>> selector,
            CancellationToken                  cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<decimal?> AverageAsync<TSource>(
            IQueryable<TSource>                 source,
            Expression<Func<TSource, decimal?>> selector,
            CancellationToken                   cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public Task<double> AverageAsync(
            IQueryable<int>   source,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public Task<double?> AverageAsync(
            IQueryable<int?>  source,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<double> AverageAsync<TSource>(
            IQueryable<TSource>            source,
            Expression<Func<TSource, int>> selector,
            CancellationToken              cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<double?> AverageAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, int?>> selector,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public Task<double> AverageAsync(
            IQueryable<long>  source,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public Task<double?> AverageAsync(
            IQueryable<long?> source,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<double> AverageAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, long>> selector,
            CancellationToken               cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<double?> AverageAsync<TSource>(
            IQueryable<TSource>              source,
            Expression<Func<TSource, long?>> selector,
            CancellationToken                cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public Task<double> AverageAsync(
            IQueryable<double> source,
            CancellationToken  cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public Task<double?> AverageAsync(
            IQueryable<double?> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<double> AverageAsync<TSource>(
            IQueryable<TSource>               source,
            Expression<Func<TSource, double>> selector,
            CancellationToken                 cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<double?> AverageAsync<TSource>(
            IQueryable<TSource>                source,
            Expression<Func<TSource, double?>> selector,
            CancellationToken                  cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public Task<float> AverageAsync(
            IQueryable<float> source,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        public Task<float?> AverageAsync(
            IQueryable<float?> source,
            CancellationToken  cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<float> AverageAsync<TSource>(
            IQueryable<TSource>              source,
            Expression<Func<TSource, float>> selector,
            CancellationToken                cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source, selector));
        }

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        public Task<float?> AverageAsync<TSource>(
            IQueryable<TSource>               source,
            Expression<Func<TSource, float?>> selector,
            CancellationToken                 cancellationToken = default)
        {
            return Task.FromResult(Queryable.Average(source, selector));
        }

        /// <summary>
        /// Asynchronously determines whether a sequence contains a specified element by using the default equality comparer.
        /// </summary>
        public Task<bool> ContainsAsync<TSource>(
            IQueryable<TSource> source,
            TSource             item,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Queryable.Contains(source, item));
        }

        /// <summary>
        /// Asynchronously creates a list from an IQueryable by enumerating it asynchronously.
        /// </summary>
        public Task<List<TSource>> ToListAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Enumerable.ToList(source));
        }

        /// <summary>
        /// Asynchronously creates an array from an IQueryable by enumerating it asynchronously.
        /// </summary>
        public Task<TSource[]> ToArrayAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default)
        {
            return Task.FromResult(Enumerable.ToArray(source));
        }


        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector function.
        /// </summary>
        public Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(
            IQueryable<TSource> source,
            Func<TSource, TKey> keySelector,
            CancellationToken   cancellationToken = default) where TKey : notnull
        {
            return Task.FromResult(Enumerable.ToDictionary(source, keySelector));
        }

        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector function and a comparer.
        /// </summary>
        public Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(
            IQueryable<TSource>     source,
            Func<TSource, TKey>     keySelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken       cancellationToken = default) where TKey : notnull
        {
            return Task.FromResult(Enumerable.ToDictionary(source, keySelector, comparer));
        }

        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector and an element selector function.
        /// </summary>
        public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(
            IQueryable<TSource>     source,
            Func<TSource, TKey>     keySelector,
            Func<TSource, TElement> elementSelector,
            CancellationToken       cancellationToken = default) where TKey : notnull
        {
            return Task.FromResult(Enumerable.ToDictionary(source, keySelector, elementSelector));
        }

        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector function, a comparer, and an element selector function.
        /// </summary>
        public Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(
            IQueryable<TSource>     source,
            Func<TSource, TKey>     keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken       cancellationToken = default) where TKey : notnull
        {
            return Task.FromResult(Enumerable.ToDictionary(source, keySelector, elementSelector, comparer));
        }

        /// <summary>
        /// Get query provider supported
        /// </summary>
        public Type QueryProvider => typeof(AsyncToSyncQueryableProvider);
    }
}