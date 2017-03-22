using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Study.DataStructures
{
    [TestFixture]
    public class SimpleLinkedListTests
    {
        #region AddFirst

        [Test]
        public void AddFirstTestHead()
        {
            SimpleLinkedList<int> linkedList = new SimpleLinkedList<int>();

            linkedList.AddFirst(5);
            linkedList.AddFirst(4);
            linkedList.AddFirst(3);
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);
            Assert.AreEqual(1, linkedList.Head.Value);
            
        }

        [Test]
        public void AddFirstTestTail()
        {
            SimpleLinkedList<int> linkedList = new SimpleLinkedList<int>();

            linkedList.AddFirst(5);
            linkedList.AddFirst(4);
            linkedList.AddFirst(3);
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);
            Assert.AreEqual(5, linkedList.Tail.Value);
        }

        [Test]
        public void AddFirstTestCount()
        {
            SimpleLinkedList<int> linkedList = new SimpleLinkedList<int>();

            linkedList.AddFirst(5);
            linkedList.AddFirst(4);
            linkedList.AddFirst(3);
            linkedList.AddFirst(2);
            linkedList.AddFirst(1);
            Assert.AreEqual(5, linkedList.Count);
        }

        #endregion

        #region AddLast

        [Test]
        public void AddLastTestHead()
        {
            SimpleLinkedList<int> linkedList = new SimpleLinkedList<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Assert.AreEqual(1, linkedList.Head.Value);
        }


        [Test]
        public void AddLastTestTail()
        {
            SimpleLinkedList<int> linkedList = new SimpleLinkedList<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Assert.AreEqual(3, linkedList.Tail.Value);
        }

        [Test]
        public void AddLastTestCount()
        {
            SimpleLinkedList<int> linkedList = new SimpleLinkedList<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            Assert.AreEqual(4, linkedList.Count);
        }

        #endregion

        #region RemoveFirst

        [Test]
        public void RemoveFirstTestOneNode()
        {
            //arrange
            var sut = new SimpleLinkedList<int>();

            //act
            sut.AddFirst(4);
            sut.RemoveFirst();
            
            //assert
            Assert.That(sut.Tail, Is.Null);

        }

        [Test]
        public void RemoveFirstTestSecond()
        {
            var sut = new SimpleLinkedList<int>();

            sut.AddFirst(1);
            sut.AddFirst(2);
            sut.AddFirst(3);

            sut.RemoveFirst();

            Assert.That(sut.Head.Value, Is.EqualTo(2));

        }

#endregion
    }
}
