using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTask4
{
    internal class SmartStack<T>
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

        public SmartStack(IEnumerable<T> values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            _capacity = values.Count();
            _array = new T[_capacity];
            _count = 0;

            foreach (T value in values)
            {
                _array[_count++] = value;
            }

        }

        public void Push(T item)
        {
            if (_count == _capacity)
            {
                _capacity = _capacity * 2;
            }
            _array[_count++] = item;
        }

        public void PushRange(IEnumerable<T> values)
        {
            _capacity = _capacity + values.Count();
            
            foreach (T value in values)
            {
                _array[_count++] = value;
            }
        }

        public void Pop()
        {
            T result = _array[_count--];
            T result = default(T);
        }
    }
}
