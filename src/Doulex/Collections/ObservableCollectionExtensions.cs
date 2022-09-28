using System.Collections.ObjectModel;

namespace Doulex.Collections
{
    /// <summary>
    /// The extensions of Observable Collection 
    /// </summary>
    public static class ObservableCollectionExtensions
    {
        /// <summary>
        /// Replace the element of source with collection,
        /// 
        /// follow the rule
        /// 1. If the data in the source. Then skip it
        /// 2. If the data is not in the source. Then add it to the source
        /// 3. If the data is in the source but not in the collection, Then remove it from source
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TNew"></typeparam>
        /// <param name="source"></param>
        /// <param name="newCollection">the new collection that will replace to the source</param>
        /// <param name="equatable">the equatable compare, T: orgValue T: newValue bool: the object is equal</param>
        /// <param name="transformCallback">Add the value to source collection</param>
        /// <param name="replaceCallback">Replace policy, T: orgValue T: newValue bool: replace with newValue</param>
        public static void ReplaceWith<TSource, TNew>(
            this ObservableCollection<TSource> source,
            TNew[]                             newCollection,
            Func<TSource, TNew, bool>          equatable,
            Func<TNew, TSource>                transformCallback,
            Action<TSource, TNew>              replaceCallback)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (newCollection == null)
                throw new ArgumentNullException(nameof(newCollection));
            if (equatable == null)
                throw new ArgumentNullException(nameof(equatable));
            if (transformCallback == null)
                throw new ArgumentNullException(nameof(transformCallback));

            HashSet<TSource> hits = new();

            // Update exists
            foreach (var newObject in newCollection)
            {
                var exists = source.SingleOrDefault(c => equatable(c, newObject));
                if (exists == null)
                {
                    var insert = transformCallback(newObject);
                    source.Add(insert);
                    hits.Add(insert);
                    continue;
                }

                // execute update
                replaceCallback?.Invoke(exists, newObject);
                hits.Add(exists);
            }

            // remove no longer exists
            var removes = (from item in source
                           where !hits.Contains(item)
                           select item).ToArray();

            foreach (var item in removes)
            {
                source.Remove(item);
            }
        }
    }
}