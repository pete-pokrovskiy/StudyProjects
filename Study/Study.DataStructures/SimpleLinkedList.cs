﻿using System;
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

        public int Count { get; set; }

    }
}
