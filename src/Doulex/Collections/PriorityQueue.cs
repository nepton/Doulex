namespace Doulex.Collections;

/// <summary>
/// Priority Queue
/// </summary>
/// <typeparam name="TElement">The type of the actual elements that are stored</typeparam>
/// <typeparam name="TPriority">The type of the priority.</typeparam>
public class PriorityQueue<TElement, TPriority> where TPriority : notnull
{
    private readonly SortedDictionary<TPriority, Queue<TElement?>> _dict = new();

    /// <summary>
    /// Enqueue the element, and specified the priority
    /// </summary>
    /// <param name="item"></param>
    /// <param name="priority"></param>
    public void Enqueue(TElement item, TPriority priority)
    {
        if (!_dict.TryGetValue(priority, out var queue))
        {
            queue = new Queue<TElement?>();
            _dict.Add(priority, queue);
        }

        queue.Enqueue(item);
        _count += 1;
    }

    /// <summary>
    /// Clear the queue
    /// </summary>
    public void Clear()
    {
        _dict.Clear();
        _count = 0;
    }

    /// <summary>
    /// Clear the queue by the priority
    /// </summary>
    /// <param name="priority"></param>
    public void Clear(TPriority priority)
    {
        _dict.Remove(priority);
    }

    /// <summary>
    /// Try dequeue the element from queue, if succeeded return true otherwise return false
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public bool TryDequeue(out TElement? element)
    {
        if (_dict.Count == 0)
        {
            element = default;
            return false;
        }

        var key   = _dict.Keys.First();
        var queue = _dict[key];

        element =  queue.Dequeue();
        _count  -= 1;

        // Remove if empty
        if (queue.Count == 0)
            _dict.Remove(key);

        return true;
    }

    /// <summary>
    /// Dequeue the element from queue
    /// </summary>
    /// <returns></returns>
    public TElement? Dequeue()
    {
        if (!TryDequeue(out var element))
            throw new InvalidOperationException("Queue is empty");

        return element;
    }

    private int _count;

    /// <summary>
    /// Number of element
    /// </summary>
    public int Count => _count; // 为了性能, 不要每次计算

    /// <summary>
    /// 获取指定的优先级的Count
    /// </summary>
    /// <param name="priority"></param>
    /// <returns></returns>
    public int CountByPriority(TPriority priority)
    {
        if (!_dict.TryGetValue(priority, out var queue))
            return 0;

        return queue.Count;
    }

    /// <summary>
    /// return the top of the queue, keep this element in queue
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public bool TryPeek(out TElement? element)
    {
        if (_dict.Count == 0)
        {
            element = default;
            return false;
        }

        var key   = _dict.Keys.First();
        var queue = _dict[key];

        return queue.TryPeek(out element);
    }

    /// <summary>
    /// return the top of the queue, keep this element in queue
    /// </summary>
    /// <returns></returns>
    public TElement? Peek()
    {
        if (!TryPeek(out var element))
            throw new InvalidOperationException("Queue is empty");

        return element;
    }
}
