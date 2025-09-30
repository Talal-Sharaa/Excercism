public class CircularBuffer<T>
{
    private readonly T[] _buffer;
    private int _head = 0;
    private int _tail = 0;
    private int _count = 0;
    private readonly int _capacity;

    public CircularBuffer(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than 0");
        _buffer = new T[capacity];
        _capacity = capacity;
    }

    public bool IsEmpty => _count == 0;
    public bool IsFull => _count == _capacity;

    public void Write(T value)
    {
        if (IsFull)
            throw new InvalidOperationException("Buffer is full");

        _buffer[_head] = value;
        _head = (_head + 1) % _capacity;
        _count++;
    }

    public void Overwrite(T value)
    {
        _buffer[_head] = value;
        _head = (_head + 1) % _capacity;

        if (IsFull)
            _tail = (_tail + 1) % _capacity;
        else
            _count++;
    }

    public T Read()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Buffer is empty");

        T value = _buffer[_tail];
        _tail = (_tail + 1) % _capacity;
        _count--;
        return value;
    }

    public void Clear()
    {
        _head = 0;
        _tail = 0;
        _count = 0;
        Array.Clear(_buffer, 0, _buffer.Length);
    }
}
