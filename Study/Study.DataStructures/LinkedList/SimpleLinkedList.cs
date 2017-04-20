using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Study.DataStructures
{
    public class SimpleLinkedList<T> : ICollection<T>
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
                SimpleLinkedListNode<T> tempNode = Head;
                node.Next = tempNode;
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

        public void RemoveLast()
        {
            if(Count == 0)
                return;

            if (Count == 1)
            {
                Head = null;
                Tail = null;
                Count--;
                return;
            }

            //получим узел, которые ссылется на хвост
            SimpleLinkedListNode<T> preTail = Head;
            while (preTail.Next != Tail)
            {
                preTail = preTail.Next;
            }

            preTail.Next = null;
            Tail = preTail;

            Count --;

        }

        public bool Remove(T valueToDelete)
        {
            if (Count == 0)
                return false;


            SimpleLinkedListNode<T> previousNode = null;
            SimpleLinkedListNode<T> currentNode = Head;

            while (currentNode != null)
            {
                if(currentNode == Head &&  currentNode.Value.Equals(valueToDelete))
                    RemoveFirst();

               else if (currentNode == Tail && currentNode.Value.Equals(valueToDelete))
               {
                   RemoveLast();
                   currentNode = null;
                   continue;
               }
               else if (currentNode.Value.Equals(valueToDelete))
               {
                   previousNode.Next = currentNode.Next;
                   Count--;
               }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            return true;

        }

        public int Count { get; set; }

        public bool IsReadOnly => false;


        public void Add(T item)
        {
           AddFirst(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;

            Count = 0;
        }

        public bool Contains(T value)
        {
            SimpleLinkedListNode<T> node = Head;

            while (node != null)
            {
                if (node.Value.Equals(value))
                    return true;
                node = node.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            SimpleLinkedListNode<T> currentNode = Head;

            while (currentNode != null)
            {
                array[arrayIndex] = currentNode.Value;

                arrayIndex++;

                currentNode = currentNode.Next;
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            SimpleLinkedListNode<T> node = Head;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
