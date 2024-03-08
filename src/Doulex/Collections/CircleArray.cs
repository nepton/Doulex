using System.Collections;

namespace Doulex.Collections;

/// <summary>
/// Circle is a collection that has a fixed size and behaves like a circle.
/// </summary>
/// <typeparam name="T">The type of the element saved in the array</typeparam>
public class CircleArray<T> : IEnumerable<T>
{
    /// <summary>
    /// Returns the size of the circle.
    /// </summary>
    private int _index;

    /// <summary>
    /// Saves the array.
    /// </summary>
    private readonly T[] _array;

    /// <summary>
    /// Initializes a new instance of the <see cref="CircleArray{T}"/> class.
    /// </summary>
    /// <param name="size">The size of the circle.</param>
    public CircleArray(int size)
    {
        if (size <= 0)
            throw new ArgumentOutOfRangeException(nameof(size));

        _array = new T[size];
        _index = 0;
    }

    /// <summary>
    /// Returns the length of the circle.
    /// </summary>
    public int Length => Math.Min(_index, _array.Length);

    /// <summary>
    /// Returns the size of the circle.
    /// </summary>
    public int Size => _array.Length;

    /// <summary>
    /// Returns the array of the circle.
    /// </summary>
    /// <returns></returns>
    public T[] ToArray()
    {
        var result = new T[Length];

        var length = Length;
        var index  = _index % _array.Length;
        for (var i = 0; i < length; i++)
        {
            result[i] = _array[index];
            index     = (index + 1) % _array.Length;
        }

        return result;
    }

    /// <summary>
    /// Add a value to the circle.
    /// </summary>
    /// <param name="value"></param>
    public void Add(T value)
    {
        _array[_index++ % _array.Length] = value;
    }

    /// <summary>
    /// Clear the circle.
    /// </summary>
    public void Clear()
    {
        _index = 0;
    }

    /// <summary>
    /// Get the enumerator of the circle.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator()
    {
        if (_index < _array.Length)
        {
            for (var i = 0; i < _index; i++)
            {
                yield return _array[i];
            }
        }
        else
        {
            var index = _index % _array.Length;
            for (var i = 0; i < _array.Length; i++)
            {
                yield return _array[index];
                index = (index + 1) % _array.Length;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
};
