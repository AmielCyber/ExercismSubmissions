public class CircularBuffer<T>
{
    private readonly T?[] _buffer;
    private int _bufferLength;
    private int _readIndex;
    private int _writeIndex;

    public CircularBuffer(int capacity)
    {
        _buffer = new T?[capacity];
        _writeIndex = GetRandomIndex();
        _readIndex = _writeIndex;
        _bufferLength = 0;
    }

    public T Read()
    {
        if(IsEmpty())
            throw new InvalidOperationException("Can not read from an empty buffer.");
        T value = _buffer[_readIndex] ?? throw new NullReferenceException("Buffer read value should not be null.");
        _readIndex = GetNextCircularIndex(_readIndex);
        _bufferLength--;
        return value;
    }

    public void Write(T value)
    {
        if(IsFull())
            throw new InvalidOperationException("Can not write to a full buffer.");
        _buffer[_writeIndex] = value;
        _writeIndex = GetNextCircularIndex(_writeIndex);
        _bufferLength++;
    }

    public void Overwrite(T value)
    {
        if (IsFull())
        {
            _buffer[_readIndex] = value;
            _readIndex = GetNextCircularIndex(_readIndex);
        }
        else
        {
            Write(value);
        }
    }

    public void Clear()
    {
        for(int i = 0; i < _bufferLength; i++)
            _buffer[i] = default;
        _writeIndex = GetRandomIndex();
        _readIndex = _writeIndex;
        _bufferLength = 0;
    }

    private int GetRandomIndex() => (new Random()).Next(0, _buffer.Length);

    private int GetNextCircularIndex(int index)
    {
        index += 1;
        if (index >= _buffer.Length)
            return index % _buffer.Length;
        return index;
    }

    private bool IsFull() => _bufferLength == _buffer.Length;

    private bool IsEmpty() => _bufferLength == 0;
}
