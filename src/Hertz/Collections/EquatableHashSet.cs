using System.Runtime.CompilerServices;

namespace Hertz.Collections
{
    /// <summary>
    /// This class is used to equality comparer for a type.
    /// for the array member of record type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EquatableHashSet<T> : HashSet<T>
        where T : IEquatable<T>
    {
        public EquatableHashSet()
        {
        }

        public EquatableHashSet(params T[] collection) : base(collection)
        {
        }

        public EquatableHashSet(IEnumerable<T> collection) : base(collection)
        {
        }

        /// <summary>Serves as the default hash function.</summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var item in this)
            {
                hash ^= item.GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (obj is IEnumerable<T> other)
            {
                return SetEquals(other);
            }

            return RuntimeHelpers.Equals(this, obj);
        }
    }
}
