using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DataStructures
{
    public class SimpleLinkedListStack<T> : IEnumerable<T>
    {
        /// <summary>
        /// Используем связанный список из библиотеки
        /// </summary>
        LinkedList<T> _list = new LinkedList<T>(); 

        public void Push(T value)
        {
            _list.AddFirst(value);
        }

        public T Pop()
        {
            if(Count == 0)
                throw new Exception("empty");

            T value = _list.First.Value;

            _list.RemoveFirst();

            return value;
        }


        public T Peek()
        {
            if (Count == 0)
                throw new Exception("empty");

            T value = _list.First.Value;

            return value;
        }

        public int Count => _list.Count;

        public void Clear()
        {
            _list.Clear();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
