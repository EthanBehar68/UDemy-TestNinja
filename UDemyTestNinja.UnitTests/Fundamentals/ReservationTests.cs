using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using UDemyTestNinja.Fundamentals;

namespace UDemyTestNinja.UnitTests
{
    // Test Class Naming Convention = 
    // ClassWeAreTesting + Tests
    //[TestClass] - MS Test Convention
    [TestFixture]
    public class ReservationTests
    {
        // Test Method Naming Convention =
        // MethodWeAreTesting_TestingScenario_ExpectedBehavior
        //[TestMethod] - MS Test Convention
        [Test]
        //[Ignore("Not Testing Yet")]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            //Assert.IsTrue(result); - MS Test Convention
            Assert.That(result, Is.True);
            //Assert.That(result == true); - Another means
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void CanBeCancelledBy_MadeByUserCancelling_ReturnsTrue()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        //[Ignore("Not Testing Yet")]
        public void CanBeCancelledBy_NotMadeByUserOrAdminCancelling_ReturnsFalse()
        {
            // Arrange
            //var user = new User();
            //var anotherUser = new User();
            //var reservation = new Reservation { MadeBy = user };
            var reservation = new Reservation { MadeBy = new User() };

            // Act
            //var result = reservation.CanBeCancelledBy(anotherUser);
            var result = reservation.CanBeCancelledBy(new User());
            // Assert
            Assert.That(result, Is.False);
        }
    }
}
