using System.Collections;

namespace LinkedListImplementation;

public class MyList<T> : ICollection<T>
{
    private MyListNode<T>? _firstNode;
    private MyListNode<T>? _lastNode;

    public IEnumerator<T> GetEnumerator()
    {
        var actual = _firstNode;
        while (actual != null)
        {
            yield return actual.Value;
            actual = actual.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        MyListNode<T> newNode = new(item);
        if (IsEmpty)
        {
            _firstNode = _lastNode = newNode;
        }
        else
        {
            if (_lastNode == null) throw new Exception("List was not initialized, imposible bug");
            _lastNode.Next = newNode;
            _lastNode = newNode;
        }
        Count++;
    }

    public void Clear()
    {
        _firstNode = null;
        _lastNode = null;
    }

    public bool Contains(T item) => Enumerable.Contains(this, item);

    public void CopyTo(T[] array, int arrayIndex)
    {
        var i = 0;
        foreach (var val in this)
        {
            array[arrayIndex + i] = val;
            i++;
        }
    }

    public bool Remove(T item)
    {
        if (IsEmpty) return false;
        var actual = _firstNode;
        var prev = _firstNode;
        
        while (actual != null)
        {
            if (actual.Value != null && actual.Value.Equals(item))
            {
                prev.Next = actual.Next;
                Count--;
                return true;
            }
            actual = actual.Next;
            prev = actual;
        }

        return false;
    }

    public int Count { get; private set; } = 0;
    public bool IsReadOnly { get; } = false;
    public bool IsEmpty => Count == 0;

    public T First => _firstNode.Value;
    public T Last => _lastNode.Value;
}
