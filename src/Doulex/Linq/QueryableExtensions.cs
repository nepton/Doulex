using System.Linq.Expressions;

namespace Doulex.Linq
{
    /// <summary>
    /// 查询扩展
    /// </summary>
    public static class QueryableExtensions
    {
        private static IQueryable<TSource> WhereWhenCore<TSource>(
            this IQueryable<TSource>        source,
            bool                            whenTrue,
            Expression<Func<TSource, bool>> predicate)
        {
            if (whenTrue)
                return source.Where(predicate);

            return source;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="whenTrue"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IQueryable<TSource> WhereWhen<TSource>(
            this IQueryable<TSource>        source,
            bool                            whenTrue,
            Expression<Func<TSource, bool>> predicate)
        {
            return WhereWhenCore(source, whenTrue, predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="whenNotNull"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IQueryable<TSource> WhereWhen<TSource>(
            this IQueryable<TSource>        source,
            object?                         whenNotNull,
            Expression<Func<TSource, bool>> predicate)
        {
            return WhereWhenCore(source, whenNotNull != null, predicate);
        }
    }
}