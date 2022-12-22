namespace Doulex.Collections
{
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static class TreeExtension
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
        public static IEnumerable<TSource> Flatten<TSource>(
            this TSource                        source,
            Func<TSource, IEnumerable<TSource>> childrenSelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (childrenSelector == null)
                throw new ArgumentNullException(nameof(childrenSelector));

            return Flatten(new[] {source}, childrenSelector);
        }

        /// <summary>
        /// Traverses an object hierarchy and return a flattened list of elements
        /// based on a predicate.
        /// </summary>
        /// <param name="source">The collection of your topmost TSource objects</param>
        /// <param name="childrenSelector">A function that fetches the child collection from an object.</param>
        /// <typeparam name="TSource">The type of object in your collection</typeparam>
        /// <returns>A flattened list of objects which meet the criteria in selectorFunction.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TSource> Flatten<TSource>(
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
                var children = childrenSelector(element).Flatten(childrenSelector);
                result = result.Concat(children);
            }

            return result;
        }

        /// <summary>
        /// Convert a flatten list to a tree
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="rootSelector">The root selector</param>
        /// <param name="idSelector">The id selector</param>
        /// <param name="parentIdSelector">The parent id selector</param>
        /// <param name="childrenAssign">The children assign</param>
        /// <typeparam name="T">The type of the source</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T? ToTree<T>(
            this IEnumerable<T>       source,
            Func<IEnumerable<T>, T?>  rootSelector,
            Func<T, object?>          idSelector,
            Func<T, object?>          parentIdSelector,
            Action<T, IEnumerable<T>> childrenAssign)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (rootSelector == null) throw new ArgumentNullException(nameof(rootSelector));
            if (idSelector == null) throw new ArgumentNullException(nameof(idSelector));
            if (parentIdSelector == null) throw new ArgumentNullException(nameof(parentIdSelector));
            if (childrenAssign == null) throw new ArgumentNullException(nameof(childrenAssign));

            var array  = source as T[] ?? source.ToArray();
            var lookup = array.ToLookup(parentIdSelector);
            var root   = rootSelector(array);

            if (root == null)
            {
                return default;
            }

            var stack = new Stack<T>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var current  = stack.Pop();
                var children = lookup[idSelector(current)].ToArray();
                foreach (var child in children)
                {
                    stack.Push(child);
                }

                childrenAssign(current, children);
            }

            return root;
        }
    }
}
