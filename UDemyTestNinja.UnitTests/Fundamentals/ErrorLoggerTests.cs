using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDemyTestNinja.Fundamentals;

namespace UDemyTestNinja.UnitTests
{
    [TestFixture]
    class ErrorLoggerTests
    {
        private ErrorLogger _errorLogger;

        [SetUp]
        public void SetUp()
        {
            _errorLogger = new ErrorLogger();
        }

        [Test]
        //Testing method that is void
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            _errorLogger.Log("a");

            Assert.That(_errorLogger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        //Testing method that throws exception
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            Assert.That(() => _errorLogger.Log(error), Throws.ArgumentNullException);
            
            // Example of when keyword isn't found/used.
            //Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>());
        }

        [Test]
        //Testing method that raises event
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {

            var id = Guid.Empty;

            _errorLogger.ErrorLogged += (sender, args) => {
                id = args;
            };

            _errorLogger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
