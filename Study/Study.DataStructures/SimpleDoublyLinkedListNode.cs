using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DataStructures
{
    public class SimpleDoublyLinkedListNode<T>
    {
        public T Value { get; set; }

        public SimpleDoublyLinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// ссылка на предыдущий узел
        /// </summary>
        public SimpleDoublyLinkedListNode<T> Previous { get; set; }

        public SimpleDoublyLinkedListNode<T> Next { get; set; } 
    }
}
