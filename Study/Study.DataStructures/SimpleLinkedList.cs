using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DataStructures
{
    public class SimpleLinkedList<T>
    {
        public SimpleLinkedList() 
        {
            Head = null;
            Tail = null;
        } 

        private SimpleLinkedListNode<T> Head { get; set; }
        private SimpleLinkedListNode<T> Tail { get; set; }


        public void AddFirst(T value)
        {
            
        }




    }
}
