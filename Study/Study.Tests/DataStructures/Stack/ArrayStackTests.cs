using NUnit.Framework;
using Study.DataStructures.Stack;

namespace Study.Tests.DataStructures.Stack
{
    [TestFixture]
    public class ArrayStackTests
    {

        //naming conventions? Should_ExpectedBehavior_When_StateUnderTest

        [Test]
        public void Should_CountEqualsTwelve_WhenPushNoElements()
        {
            //arrange
            ArrayStack<int> sut = new ArrayStack<int>();

            //act
            sut.Push(1);
            sut.Push(2);
            sut.Push(3);
            sut.Push(4);
            sut.Push(5);
            sut.Push(6);
            sut.Push(7);
            sut.Push(8);
            sut.Push(9);
            sut.Push(10);
            sut.Push(11);
            sut.Push(12);

            //assert
            Assert.That(sut.Count, Is.EqualTo(12));
        }

        [Test]
        public void Should_CountEqualsTwo_When_PushNoElements()
        {
            //arrange
            ArrayStack<int> sut = new ArrayStack<int>();

            //act
            sut.Push(1);
            sut.Push(2);

            //assert
            Assert.That(sut.Count, Is.EqualTo(2));
        }

        [Test]
        public void Should_ThrowException_When_PopEmpty()
        {
            ArrayStack<int> sut = new ArrayStack<int>();

            Assert.That(() => sut.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Should_ReturnTwo_When_Pop()
        {
            ArrayStack<int> sut = new ArrayStack<int>();

            sut.Push(1);
            sut.Push(2);

            var popped = sut.Pop();

            Assert.That(popped, Is.EqualTo(2));
        }

        [Test]
        public void Should_DecreaseCount_When_Pop()
        {
            var sut = new ArrayStack<int>();

            sut.Push(1);
            sut.Push(2);
            sut.Push(3);

            sut.Pop();

            Assert.That(sut.Count, Is.EqualTo(2));
        }

        [Test]
        public void Should_HaveSameCount_When_Peek()
        {
            var sut = new ArrayStack<int>();

            sut.Push(1);
            sut.Push(2);
            sut.Push(3);

            sut.Peek();

            Assert.That(sut.Count, Is.EqualTo(3));
        }

    }
}
