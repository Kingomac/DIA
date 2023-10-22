namespace LinkedListImplementation;

internal class MyListNode<T>
{
    public T Value { get; set; }
    public MyListNode<T>? Next { get; set; } = null;
    
    public MyListNode() {}

    public MyListNode(T val)
    {
        Value = val;
    }
    public MyListNode(T val, MyListNode<T> next)
    {
        Value = val;
        Next = next;
    }
}