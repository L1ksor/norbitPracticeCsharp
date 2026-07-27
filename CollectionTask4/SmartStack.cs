using System.Collections;

namespace CollectionTask4
{
    /// <summary>
    /// Умный стек.
    /// </summary>
    /// <typeparam name="T">Тип элементов массива.</typeparam>
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

        /// <summary>
        /// Количество элементов.
        /// </summary>
        public int Count { get { return _count; } }

        /// <summary>
        /// Количество ёмкости.
        /// </summary>
        public int Capacity { get { return _capacity; } }

        /// <summary>
        /// Элемент вершины.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
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

        /// <summary>
        /// Добавление элемента на вершину.
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (_count == _capacity)
            {
                CapacityExtension();
            }

            _array[_count++] = item;
        }


        /// <summary>
        /// Добавление коллекции.
        /// </summary>
        /// <param name="values"></param>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Удаление элемента с вершины.
        /// </summary>
        /// <returns>Последний удалённый элемент</returns>
        /// <exception cref="InvalidOperationException"></exception>
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

        /// <summary>
        /// Поиск элемента
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Расширение стека вдвое
        /// </summary>
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

        /// <summary>
        /// Возвращает перечислитель для обхода элементов массива.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _count - 1; i >= 0; i--)
            {
                yield return _array[i];
            }
        }

        /// <summary>
        /// Возвращает перечислитель для обхода элементов массива.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
