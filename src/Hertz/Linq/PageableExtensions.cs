namespace Hertz.Linq
{
    /// <summary>
    /// The extensions for Pageable query result
    /// </summary>
    public static class PageableExtensions
    {
        /// <summary>
        /// Convert the query result to Pageable query result
        /// </summary>
        /// <typeparam name="TSource">The type of result</typeparam>
        /// <param name="source">the result query expression</param>
        /// <param name="skip">Indicate how many records to skip before returning results</param>
        /// <param name="take">Indicate how many records to return</param>
        /// <param name="cancel">Cancellation token</param>
        /// <returns>Return paged collection</returns>
        private static async Task<PageCollection<TSource>> ToPagesCoreAsync<TSource>(
            this IQueryable<TSource> source,
            int                      skip,
            int                      take,
            CancellationToken        cancel = default)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip));

            if (take <= 0)
                throw new ArgumentOutOfRangeException(nameof(take));

            var count = await source.CountAsync(cancellationToken: cancel);
            var data  = Array.Empty<TSource>();
            if (count > 0)
                data = await source.Skip(skip).Take(take).ToArrayAsync(cancellationToken: cancel);

            return new PageCollection<TSource>(skip, take, count, data);
        }

        /// <summary>
        /// Convert the query result to Pageable query result
        /// </summary>
        /// <typeparam name="TSource">The type of result</typeparam>
        /// <typeparam name="TSummary">The type of summary</typeparam>
        /// <param name="source">the result query expression</param>
        /// <param name="skip">Indicate how many records to skip before returning results</param>
        /// <param name="take">Indicate how many records to return</param>
        /// <param name="summary">The summary data</param>
        /// <param name="cancel">Cancellation token</param>
        /// <returns>Return paged collection</returns>
        private static async Task<PageCollection<TSource, TSummary>> ToPagesCoreAsync<TSource, TSummary>(
            this IQueryable<TSource> source,
            int                      skip,
            int                      take,
            TSummary                 summary,
            CancellationToken        cancel = default)
        {
            if (skip <= 0)
                throw new ArgumentOutOfRangeException(nameof(skip));

            if (take <= 0)
                throw new ArgumentOutOfRangeException(nameof(take));

            var count = await source.CountAsync(cancellationToken: cancel);
            var data  = await source.Skip((skip - 1) * take).Take(take).ToArrayAsync(cancellationToken: cancel);

            var page = new PageCollection<TSource, TSummary>(skip, take, count, data, summary);

            return page;
        }

        /// <summary>
        /// Convert the query result to Pageable query result
        /// </summary>
        /// <typeparam name="TSource">The type of result</typeparam>
        /// <param name="source">the result query expression</param>
        /// <param name="skip">Indicate how many records to skip before returning results</param>
        /// <param name="take">Indicate how many records to return</param>
        /// <param name="cancel">Cancellation token</param>
        /// <returns>Return paged collection</returns>
        public static Task<PageCollection<TSource>> ToPagesAsync<TSource>(
            this IQueryable<TSource> source,
            int                      skip,
            int                      take,
            CancellationToken        cancel = default)
        {
            return ToPagesCoreAsync(source, skip, take, cancel);
        }

        /// <summary>
        /// Convert the query result to Pageable query result
        /// </summary>
        /// <typeparam name="TSource">The type of result</typeparam>
        /// <param name="source">the result query expression</param>
        /// <param name="pageQueryFilter">the query filter about paged</param>
        /// <param name="cancel">Cancellation token</param>
        /// <returns>Return paged collection</returns>
        public static Task<PageCollection<TSource>> ToPagesAsync<TSource>(this IQueryable<TSource> source, PageableQueryFilter pageQueryFilter, CancellationToken cancel = default)
        {
            if (pageQueryFilter == null)
                throw new ArgumentNullException(nameof(pageQueryFilter));

            var result = ToPagesCoreAsync(source, (int) pageQueryFilter.Skip, (int) pageQueryFilter.Take, cancel);
            return result;
        }

        /// <summary>
        /// Convert the query result to Pageable query result
        /// </summary>
        /// <typeparam name="TSource">The type of result</typeparam>
        /// <typeparam name="TSummary">The type of summary</typeparam>
        /// <param name="source">the result query expression</param>
        /// <param name="pageQueryFilter">the query filter about paged</param>
        /// <param name="summary">The summary data</param>
        /// <param name="cancel">Cancellation token</param>
        /// <returns>Return paged collection</returns>
        public static Task<PageCollection<TSource, TSummary>> ToPagesAsync<TSource, TSummary>(
            this IQueryable<TSource> source,
            PageableQueryFilter      pageQueryFilter,
            TSummary                 summary,
            CancellationToken        cancel = default)
        {
            if (pageQueryFilter == null)
                throw new ArgumentNullException(nameof(pageQueryFilter));

            return ToPagesCoreAsync(source, pageQueryFilter.Skip, pageQueryFilter.Take, summary, cancel);
        }

        /// <summary>
        /// Convert paged query result to another Pageable query result
        /// </summary>
        /// <typeparam name="TSource">The type of result</typeparam>
        /// <typeparam name="TResult">The new type of result</typeparam>
        /// <param name="source">the result query expression</param>
        /// <param name="selector">The selector is used to convert</param>
        /// <returns>Return paged collection</returns>
        public static PageCollection<TResult> Select<TSource, TResult>(this PageCollection<TSource> source, Func<TSource, TResult> selector)
        {
            return new PageCollection<TResult>(source.Skip, source.Take, source.Total, source.Items.Select(selector).ToArray());
        }
    }
}
