using System.Linq.Expressions;

namespace Doulex
{
    /// <summary>
    /// Queryable extension
    /// </summary>
    public static class QueryableOrderExtensions
    {
        /// <summary>
        /// Order the query
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="isAscending"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(
            this IQueryable<TSource>        source,
            Expression<Func<TSource, TKey>> keySelector,
            bool                            isAscending)
        {
            if (isAscending)
                return source.OrderBy(keySelector);

            return source.OrderByDescending(keySelector);
        }
    }
}
