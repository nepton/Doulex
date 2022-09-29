using System.Linq.Expressions;

namespace Hertz.Linq
{
    /// <summary>
    /// IAsyncQueryable is a wrapper for IQueryable that allows for async operations.
    /// </summary>
    public interface IAsyncQueryableMethodsProvider
    {
        /// <summary>
        /// Asynchronously determines whether a sequence contains any elements.
        /// </summary>
        Task<bool> AnyAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously determines whether any element of a sequence satisfies a condition.
        /// </summary>
        Task<bool> AnyAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously determines whether all the elements of a sequence satisfy a condition.
        /// </summary>
        Task<bool> AllAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the number of elements in a sequence.
        /// </summary>
        Task<int> CountAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the number of elements in a sequence that satisfy a condition.
        /// </summary>
        Task<int> CountAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously returns an <see cref="T:System.Int64" /> that represents the total number of elements in a sequence.
        /// </summary>
        Task<long> LongCountAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously returns an <see cref="T:System.Int64" /> that represents the number of elements in a sequence that satisfy a condition.
        /// </summary>
        Task<long> LongCountAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the first element of a sequence.
        /// </summary>
        Task<TSource> FirstAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the first element of a sequence that satisfies a specified condition.
        /// </summary>
        Task<TSource> FirstAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the first element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        Task<TSource?> FirstOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the first element of a sequence that satisfies a specified condition or a default value if no such element is found.
        /// </summary>
        Task<TSource?> FirstOrDefaultAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the last element of a sequence.
        /// </summary>
        Task<TSource> LastAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the last element of a sequence that satisfies a specified condition.
        /// </summary>
        Task<TSource> LastAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the last element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>
        Task<TSource?> LastOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the last element of a sequence that satisfies a specified condition or a default value if no such element is found.
        /// </summary>
        Task<TSource?> LastOrDefaultAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>
        Task<TSource> SingleAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
        /// </summary>
        Task<TSource> SingleAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the only element of a sequence, or a default value if the sequence is empty; this method throws an exception if there is more than one element in the sequence.
        /// </summary>
        Task<TSource?> SingleOrDefaultAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the only element of a sequence that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
        /// </summary>
        Task<TSource?> SingleOrDefaultAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, bool>> predicate,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the minimum value of a sequence.
        /// </summary>
        Task<TSource?> MinAsync<TSource>(IQueryable<TSource> source,
            CancellationToken                                cancellationToken = default);

        /// <summary>
        /// Asynchronously invokes a projection function on each element of a sequence and returns the minimum resulting value.
        /// </summary>
        Task<TResult?> MinAsync<TSource, TResult>(IQueryable<TSource> source,
            Expression<Func<TSource, TResult>>                        selector,
            CancellationToken                                         cancellationToken = default);

        /// <summary>
        /// Asynchronously returns the maximum value of a sequence.
        /// </summary>
        Task<TSource?> MaxAsync<TSource>(IQueryable<TSource> source,
            CancellationToken                                cancellationToken = default);

        /// <summary>
        /// Asynchronously invokes a projection function on each element of a sequence and returns the maximum resulting value.
        /// </summary>
        Task<TResult?> MaxAsync<TSource, TResult>(IQueryable<TSource> source,
            Expression<Func<TSource, TResult>>                        selector,
            CancellationToken                                         cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        Task<decimal> SumAsync(
            IQueryable<decimal> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        Task<decimal?> SumAsync(
            IQueryable<decimal?> source,
            CancellationToken    cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<decimal> SumAsync<TSource>(
            IQueryable<TSource>                source,
            Expression<Func<TSource, decimal>> selector,
            CancellationToken                  cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<decimal?> SumAsync<TSource>(
            IQueryable<TSource>                 source,
            Expression<Func<TSource, decimal?>> selector,
            CancellationToken                   cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        Task<int> SumAsync(
            IQueryable<int>   source,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        Task<int?> SumAsync(
            IQueryable<int?>  source,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<int> SumAsync<TSource>(
            IQueryable<TSource>            source,
            Expression<Func<TSource, int>> selector,
            CancellationToken              cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<int?> SumAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, int?>> selector,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        Task<long> SumAsync(
            IQueryable<long>  source,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        Task<long?> SumAsync(
            IQueryable<long?> source,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<long> SumAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, long>> selector,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<long?> SumAsync<TSource>(
            IQueryable<TSource>              source,
            Expression<Func<TSource, long?>> selector,
            CancellationToken                cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        Task<double> SumAsync(
            IQueryable<double> source,
            CancellationToken  cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        Task<double?> SumAsync(
            IQueryable<double?> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<double> SumAsync<TSource>(
            IQueryable<TSource>               source,
            Expression<Func<TSource, double>> selector,
            CancellationToken                 cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<double?> SumAsync<TSource>(
            IQueryable<TSource>                source,
            Expression<Func<TSource, double?>> selector,
            CancellationToken                  cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        Task<float> SumAsync(
            IQueryable<float> source,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of a sequence of values.
        /// </summary>
        Task<float?> SumAsync(
            IQueryable<float?> source,
            CancellationToken  cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<float> SumAsync<TSource>(
            IQueryable<TSource>              source,
            Expression<Func<TSource, float>> selector,
            CancellationToken                cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the sum of the sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<float?> SumAsync<TSource>(
            IQueryable<TSource>               source,
            Expression<Func<TSource, float?>> selector,
            CancellationToken                 cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        Task<decimal> AverageAsync(
            IQueryable<decimal> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        Task<decimal?> AverageAsync(
            IQueryable<decimal?> source,
            CancellationToken    cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<decimal> AverageAsync<TSource>(
            IQueryable<TSource>                source,
            Expression<Func<TSource, decimal>> selector,
            CancellationToken                  cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<decimal?> AverageAsync<TSource>(
            IQueryable<TSource>                 source,
            Expression<Func<TSource, decimal?>> selector,
            CancellationToken                   cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        Task<double> AverageAsync(
            IQueryable<int>   source,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        Task<double?> AverageAsync(
            IQueryable<int?>  source,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<double> AverageAsync<TSource>(
            IQueryable<TSource>            source,
            Expression<Func<TSource, int>> selector,
            CancellationToken              cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<double?> AverageAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, int?>> selector,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        Task<double> AverageAsync(
            IQueryable<long>  source,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        Task<double?> AverageAsync(
            IQueryable<long?> source,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<double> AverageAsync<TSource>(
            IQueryable<TSource>             source,
            Expression<Func<TSource, long>> selector,
            CancellationToken               cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<double?> AverageAsync<TSource>(
            IQueryable<TSource>              source,
            Expression<Func<TSource, long?>> selector,
            CancellationToken                cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        Task<double> AverageAsync(
            IQueryable<double> source,
            CancellationToken  cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        Task<double?> AverageAsync(
            IQueryable<double?> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<double> AverageAsync<TSource>(
            IQueryable<TSource>               source,
            Expression<Func<TSource, double>> selector,
            CancellationToken                 cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<double?> AverageAsync<TSource>(
            IQueryable<TSource>                source,
            Expression<Func<TSource, double?>> selector,
            CancellationToken                  cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        Task<float> AverageAsync(
            IQueryable<float> source,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values.
        /// </summary>
        Task<float?> AverageAsync(
            IQueryable<float?> source,
            CancellationToken  cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<float> AverageAsync<TSource>(
            IQueryable<TSource>              source,
            Expression<Func<TSource, float>> selector,
            CancellationToken                cancellationToken = default);

        /// <summary>
        /// Asynchronously computes the average of a sequence of values that is obtained by invoking a projection function on each element of the input sequence.
        /// </summary>
        Task<float?> AverageAsync<TSource>(
            IQueryable<TSource>               source,
            Expression<Func<TSource, float?>> selector,
            CancellationToken                 cancellationToken = default);

        /// <summary>
        /// Asynchronously determines whether a sequence contains a specified element by using the default equality comparer.
        /// </summary>
        Task<bool> ContainsAsync<TSource>(
            IQueryable<TSource> source,
            TSource             item,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously creates a list from an IQueryable by enumerating it asynchronously.
        /// </summary>
        Task<List<TSource>> ToListAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Asynchronously creates an array from an IQueryable by enumerating it asynchronously.
        /// </summary>
        Task<TSource[]> ToArrayAsync<TSource>(
            IQueryable<TSource> source,
            CancellationToken   cancellationToken = default);

        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector function.
        /// </summary>
        Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(
            IQueryable<TSource> source,
            Func<TSource, TKey> keySelector,
            CancellationToken   cancellationToken = default) where TKey : notnull;

        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector function and a comparer.
        /// </summary>
        Task<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(
            IQueryable<TSource>     source,
            Func<TSource, TKey>     keySelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken       cancellationToken = default) where TKey : notnull;

        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector and an element selector function.
        /// </summary>
        Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(
            IQueryable<TSource>     source,
            Func<TSource, TKey>     keySelector,
            Func<TSource, TElement> elementSelector,
            CancellationToken       cancellationToken = default) where TKey : notnull;

        /// <summary>
        /// Creates a dictionary from an IQueryable by enumerating it asynchronously according to a specified key selector function, a comparer, and an element selector function.
        /// </summary>
        Task<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(
            IQueryable<TSource>     source,
            Func<TSource, TKey>     keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer,
            CancellationToken       cancellationToken = default) where TKey : notnull;

        /// <summary>
        /// Get query provider supported
        /// async queryable dispatcher will choose async methods by provider
        /// </summary>
        Type QueryProvider { get; }
    }
}