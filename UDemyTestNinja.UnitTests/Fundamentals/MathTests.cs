
using NUnit.Framework;
using System.Linq;
using TestNinja.Fundamentals;

namespace UDemyTestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(1, 1, 1)]
        //[Ignore("Not Testing Yet")]
        public void Max_WhenCalled_ReturnGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]        
        //[Ignore("Not Testing Yet")]

        public void GetOddNumbers_LimitIsGreaterThenZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            //Assert.That(result, Is.Not.Empty);

            //Assert.That(result.Count(), Is.EqualTo(3));

            //Assert.That(result, Does.Contain(5));
            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            // Good to know
            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        //[Ignore("Not Testing Yet")]
        public void GetOddNumbers_LimitIsLessThenOrEqualZero_ReturnOddNumbersUpToLimit(int a)
        {
            var result = _math.GetOddNumbers(a);

            Assert.That(result, Is.Empty);

            Assert.That(result.Count(), Is.EqualTo(0));        }
        }
    }
