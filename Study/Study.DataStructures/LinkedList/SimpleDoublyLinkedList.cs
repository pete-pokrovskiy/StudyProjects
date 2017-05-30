using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DataStructures
{
    public class SimpleDoublyLinkedList<T>
    {
        public int Count { get; private set; }

        public SimpleDoublyLinkedListNode<T> Head { get; set; }
        public  SimpleDoublyLinkedListNode<T> Tail { get; set; } 


        public void AddFirst(T value)
        {
            AddFirst(new SimpleDoublyLinkedListNode<T>(value));
        }

        public void AddFirst(SimpleDoublyLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
                Tail = node;

            }
            else
            {
                SimpleDoublyLinkedListNode<T> tempNode = Head;
                node.Next = tempNode;
                Head = node;

                tempNode.Previous = node;

            }
            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new SimpleDoublyLinkedListNode<T>(value));
        }

        public void AddLast(SimpleDoublyLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                SimpleDoublyLinkedListNode<T> temp = Tail;
                temp.Next = node;
                Tail = node;

                node.Previous = temp;
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

            Head.Previous = null;

            Count--;
        }

        public void RemoveLast()
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

            //получим узел, которые ссылется на хвост
            SimpleDoublyLinkedListNode<T> preTail = Tail.Previous;

            preTail.Next = null;
            Tail = preTail;

            Count--;
        }




    }
}
