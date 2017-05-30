using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DataStructures.Stack
{
    public class ArrayStack<T>
    {
        private int _size;

        public int Count => _size;

        private T[] _items = new T[0];

        public void Push(T value)
        {
            if (_size == _items.Length)
            {
                int newArrayLength = _size == 0 ? 4 : _size * 2;

                T[] newArray = new T[newArrayLength];

                _items.CopyTo(newArray, 0);

                _items = newArray;
            }

            _items[_size] = value;

            _size++;
        }

        public T Pop()
        {
            if(_size == 0)
                throw new InvalidOperationException("stack is empty");

            _size--;
            return _items[_size];

        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("stack is empty");

            return _items[_size - 1];
        }
    }
}
