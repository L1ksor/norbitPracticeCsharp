using System.Collections;

namespace CollectionTask4
{
    internal class SmartStack<T> : IEnumerable<T>
    {
        T[] _array;
        int _capacity;
        int _count;

        public SmartStack()
        {
            _capacity = 4;
            _array = new T[_capacity];
            _count = 0;
        }

        public SmartStack(int capacity)
        {
            _capacity = capacity;
            _array = new T[_capacity];
            _count = 0;
        }

        public SmartStack(IEnumerable<T> values) : this()
        {
            PushRange(values);
        }

        public int Count { get { return _count; } }

        public int Capacity { get { return _capacity; } }

        public T Peek() => _count != 0 ? _array[_count - 1] : throw new InvalidOperationException("Стэк пуст");

        public T this[int index]
        {
            get 
            {
                if (index > 0 && index < _count)
                {
                    return _array[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Выход на границы стека");
                }
            }
        }

        public void Push(T item)
        {
            if (_count == _capacity)
            {
                CapacityExtension();
            }

            _array[_count++] = item;
        }

        public void PushRange(IEnumerable<T> values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (T value in values)
            {
                Push(value);
            }
        }

        public T Pop()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Стэк пуст");
            }
            _count--;
            T result = _array[_count];
            _array[_count] = default(T);

            return result;
        }

        public bool Contains(T value)
        {
            bool result = false;
            foreach (var item in _array)
            {
                if (value.Equals(item))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        
        private void CapacityExtension()
        {
            _capacity = _capacity * 2;
            T[] newArray = new T[_capacity];
            for(int i = 0; i < _count; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _count - 1; i >= 0; i--)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
