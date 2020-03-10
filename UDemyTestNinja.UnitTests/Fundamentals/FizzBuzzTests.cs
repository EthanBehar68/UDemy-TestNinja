using NUnit.Framework;
using UDemyTestNinja.Fundamentals;

namespace UDemyTestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTests
    {

        // MethodWeAreTesting_TestingScenario_ExpectedBehavior
        [Test]
        //[Ignore("Ignoring for now.")]
        public void GetOutput_ArgumentIsDivisibleBy3Only_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        //[Ignore("Ignoring for now.")]
        public void GetOutput_ArgumentIsDivisibleBy5Only_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        //[Ignore("Ignoring for now.")]
        public void GetOutput_ArgumentIsDivisibleBy3And5_ReturnFizzBuss()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        //[Ignore("Ignoring for now.")]
        public void GetOutput_NumberIsNotDivisibleBy3Or5_ReturnsArgument()
        {
            var result = FizzBuzz.GetOutput(2);

            Assert.That(result, Is.EqualTo("2"));
        }
    }
}
