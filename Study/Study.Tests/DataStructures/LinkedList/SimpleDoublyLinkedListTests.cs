using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Study.DataStructures;

namespace Study.Tests.DataStructures.LinkedList
{
    /// <summary>
    /// Можно взять те же самые тесты, которы использовались для односвязного списка, только заменив тип списка
    /// </summary>
    [TestFixture]
    public class SimpleDoublyLinkedListTests
    {
        #region AddFirst

        [Test]
        public void AddFirstTestHead()
        {
            SimpleDoublyLinkedList<int> linkedList = new SimpleDoublyLinkedList<int>();

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
            SimpleDoublyLinkedList<int> linkedList = new SimpleDoublyLinkedList<int>();

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
            SimpleDoublyLinkedList<int> linkedList = new SimpleDoublyLinkedList<int>();

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
            SimpleDoublyLinkedList<int> linkedList = new SimpleDoublyLinkedList<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Assert.AreEqual(1, linkedList.Head.Value);
        }


        [Test]
        public void AddLastTestTail()
        {
            SimpleDoublyLinkedList<int> linkedList = new SimpleDoublyLinkedList<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Assert.AreEqual(3, linkedList.Tail.Value);
        }

        [Test]
        public void AddLastTestCount()
        {
            SimpleDoublyLinkedList<int> linkedList = new SimpleDoublyLinkedList<int>();

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
            var sut = new SimpleDoublyLinkedList<int>();

            //act
            sut.AddFirst(4);
            sut.RemoveFirst();

            //assert
            Assert.That(sut.Tail, Is.Null);

        }

        [Test]
        public void RemoveFirstTestSecond()
        {
            var sut = new SimpleDoublyLinkedList<int>();

            sut.AddFirst(1);
            sut.AddFirst(2);
            sut.AddFirst(3);

            sut.RemoveFirst();

            Assert.That(sut.Head.Value, Is.EqualTo(2));

        }
        #endregion

        #region RemodeLast
        [Test]
        public void RemoveLastTestHead()
        {
            //arrange
            var sut = new SimpleDoublyLinkedList<int>();

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
    }
}
