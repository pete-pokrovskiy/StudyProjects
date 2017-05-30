using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Study.DataStructures;
using Assert = NUnit.Framework.Assert;

namespace Study.Tests.DataStructures.LinkedList
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

        #region RemoveLast
        [Test]
        public void RemoveLastTestHead()
        {
            //arrange
            var sut = new SimpleLinkedList<int>();

            //act
            sut.AddFirst(1);
            sut.AddFirst(2);
            sut.AddFirst(3);
            sut.AddLast(0);
            sut.AddLast(-1);

            sut.RemoveLast();

            //assert
            Assert.That(sut.Tail.Value, Is.EqualTo(0));
        }
        #endregion
        
        #region Contains
        [Test]
        public void ContaintsTestTrue()
        {
            //arrange
            var sut = new SimpleLinkedList<int>();

            //act
            sut.AddFirst(3);
            sut.AddFirst(2);
            sut.AddFirst(10);
            sut.AddFirst(100);
            sut.AddFirst(4);
            sut.AddFirst(12);
            sut.AddFirst(456);

            //assert
            Assert.That(sut.Contains(100), Is.True);
        }

        [Test]
        public void ContainsTestFalse()
        {
            //arrange
            var sut = new SimpleLinkedList<int>();

            //act
            sut.AddFirst(3);
            sut.AddFirst(2);
            sut.AddFirst(10);
            sut.AddFirst(100);
            sut.AddFirst(4);
            sut.AddFirst(12);
            sut.AddFirst(456);
            //assert
            Assert.That(sut.Contains(101), Is.False);
        }
        #endregion

        #region Remove

        [Test]
        public void RemoveTestDistinctFirst()
        {
            //arrange
            var sut = new SimpleLinkedList<int>();

            sut.AddFirst(5);
            sut.AddFirst(4);
            sut.AddFirst(3);
            sut.AddFirst(2);
            sut.AddFirst(1);

            //act
            sut.Remove(1);

            //assert
            Assert.That(sut.Head.Value, Is.EqualTo(2));
        }

        [Test]
        public void RemoveTestDistinctLast()
        {
            //arrange
            var sut = new SimpleLinkedList<int>();

            sut.AddFirst(5);
            sut.AddFirst(4);
            sut.AddFirst(3);
            sut.AddFirst(2);
            sut.AddFirst(1);

            //act
            sut.Remove(5);

            //assert
            Assert.That(sut.Tail.Value, Is.EqualTo(4));
        }

        [Test]
        public void RemoveTestDistinctMiddle()
        {
            //arrange
            var sut = new SimpleLinkedList<int>();

            sut.AddFirst(7);
            sut.AddFirst(6);
            sut.AddFirst(5);
            sut.AddFirst(4);
            sut.AddFirst(3);
            sut.AddFirst(2);
            sut.AddFirst(1);

            //act
            sut.Remove(4);

            //assert
            Assert.That(sut.Count, Is.EqualTo(6));
        }

        [Test]
        public void RemoveTestNotDistinctCheckFirst()
        {
            //arrange
            var sut = new SimpleLinkedList<int>();

            sut.AddFirst(7);
            sut.AddFirst(6);
            sut.AddFirst(1);
            sut.AddFirst(5);
            sut.AddFirst(1);
            sut.AddFirst(1);
            sut.AddFirst(7);
            sut.AddFirst(4);
            sut.AddFirst(3);
            sut.AddFirst(7);
            sut.AddFirst(2);
            sut.AddFirst(1);
            sut.AddFirst(2);

            //act
            sut.Remove(2);

            //assert
            Assert.That(sut.Head.Value, Is.EqualTo(1));
        }

        [Test]
        public void RemoveTestNotDistinctCheckLast()
        {
            //arrange
            var sut = new SimpleLinkedList<int>();

            sut.AddFirst(7);
            sut.AddFirst(7);
            sut.AddFirst(6);
            sut.AddFirst(1);
            sut.AddFirst(5);
            sut.AddFirst(1);
            sut.AddFirst(1);
            sut.AddFirst(7);
            sut.AddFirst(4);
            sut.AddFirst(3);
            sut.AddFirst(7);
            sut.AddFirst(2);
            sut.AddFirst(1);
            sut.AddFirst(2);

            //act
            sut.Remove(7);

            //assert
            Assert.That(sut.Tail.Value, Is.EqualTo(6));
        }

        [Test]
        public void RemoveTestNotDistinctCheckCount()
        {
            //arrange
            var sut = new SimpleLinkedList<int>();

            sut.AddFirst(7);
            sut.AddFirst(7);
            sut.AddFirst(6);
            sut.AddFirst(1);
            sut.AddFirst(5);
            sut.AddFirst(1);
            sut.AddFirst(1);
            sut.AddFirst(7);
            sut.AddFirst(4);
            sut.AddFirst(3);
            sut.AddFirst(7);
            sut.AddFirst(2);
            sut.AddFirst(1);
            sut.AddFirst(2);

            //act
            sut.Remove(7);

            //assert
            Assert.That(sut.Count, Is.EqualTo(10));
        }
        #endregion

        #region CopyTo

        [Test]
        public void CopyToTest()
        {
            //arrange
            var sut = new SimpleLinkedList<int>();

            sut.AddFirst(7);
            sut.AddFirst(6);
            sut.AddFirst(5);
            sut.AddFirst(4);
            sut.AddFirst(3);
            sut.AddFirst(2);
            sut.AddFirst(1);

            //act          
            int[] array = new int[5];

            
            //assert
            Assert.That(() => sut.CopyTo(array, 0), Throws.TypeOf<IndexOutOfRangeException>());
        }

#endregion
    }
}
