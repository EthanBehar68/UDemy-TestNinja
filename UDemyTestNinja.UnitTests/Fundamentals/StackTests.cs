
using NUnit.Framework;
using UDemyTestNinja.Fundamentals;

namespace UDemyTestNinja.UnitTests
{
    [TestFixture]
    class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Count_OneElementStack_ReturnOne()
        {
            _stack.Push("a");

            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Count_TwoElementStack_ReturnTwo()
        {
            _stack.Push("a");
            _stack.Push("b");

            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Push_ArgumentIsNull_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Push_ArgumentIsValid_AddArgumentToStack()
        {
            _stack.Push("a");
            _stack.Push("b");

            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Pop_StackIsEmpty_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Pop_StackIsNotEmpty_ReturnTopElementFromStack()
        {
            _stack.Push("a");
            _stack.Push("b");
            
            var result = _stack.Pop();

            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Pop_StackIsNotEmpty_RemoveTopElementFromStack()
        {
            _stack.Push("a");
            _stack.Push("b");

            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Peek_StackIsEmpty_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Peek_StackIsNotEmpty_ReturnTopElementFromStack()
        {
            _stack.Push("a");
            _stack.Push("b");

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Peek_StackIsNotEmpty_DoesNotRemoveTopElementFromStack()
        {
            _stack.Push("a");
            _stack.Push("b");

            _stack.Peek();

            Assert.That(_stack.Count, Is.EqualTo(2));
        }
    }
}
