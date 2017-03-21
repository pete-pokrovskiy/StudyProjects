using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DataStructures
{
    public class SimpleLinkedListNode<T>
    {
        public SimpleLinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public SimpleLinkedListNode<T> Next { get; set; }
    }
}
