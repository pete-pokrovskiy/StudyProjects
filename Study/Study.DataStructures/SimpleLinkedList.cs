using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public SimpleLinkedListNode<T> Head { get; set; }
        public SimpleLinkedListNode<T> Tail { get; set; }


        public void AddFirst(T value)
        {
            AddFirst(new SimpleLinkedListNode<T>(value));   
        }

        public void AddFirst(SimpleLinkedListNode<T> node)
        {
            if (Count == 0)
            { 
                Head = node;
                Tail = node;
                
            }
            else
            {
                node.Next = Tail;
                Head = node;
            }
            Count++;

        }

        public void AddLast(T value)
        {
            AddLast(new SimpleLinkedListNode<T>(value));
        }

        public void AddLast(SimpleLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                SimpleLinkedListNode<T> temp = Tail;
                temp.Next = node;
                Tail = node;
            }

            Count++;
        }

        public void RemoveFirst()
        {

            if (Count == 0)
                return;

            if (Count == 1)
            {
                Head = null;
                Tail = null;
                Count--;
                return;
            }

            Head = Head.Next;
            Count--;

        }


        public int Count { get; set; }




    }
}
