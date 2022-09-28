namespace Doulex.Linq
{
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static class EnumerableExtension
    {
        /// <summary>
        /// Traverses an object hierarchy and return a flattened list of elements
        /// based on a predicate.
        /// </summary>
        /// <param name="source">The collection of your topmost TSource objects</param>
        /// <param name="childrenSelector">A function that fetches the child collection from an object.</param>
        /// <typeparam name="TSource">The type of object in your collection</typeparam>
        /// <returns>A flattened list of objects which meet the criteria in selectorFunction.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TSource> Flat<TSource>(
            this IEnumerable<TSource>           source,
            Func<TSource, IEnumerable<TSource>> childrenSelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (childrenSelector == null)
                throw new ArgumentNullException(nameof(childrenSelector));

            // Add what we have to the stack
            var sources = source as TSource[] ?? source.ToArray();
            var result  = sources.AsEnumerable();

            // Go through the input enumerable looking for children,
            // and add those if we have them
            foreach (var element in sources)
            {
                var children = childrenSelector(element).Flat(childrenSelector);
                result = result.Concat(children);
            }

            return result;
        }
    }
}
