

using NUnit.Framework;
using UDemyTestNinja.Fundamentals;

namespace UDemyTestNinja.UnitTests
{
    [TestFixture]
    class CustomerControllerTests
    {

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            // NotFound object only
            Assert.That(result, Is.TypeOf<NotFound>());

            // NotFound or one of its derivatives
            // Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(1);

            // NotFound object only
            Assert.That(result, Is.TypeOf<Ok>());

            // NotFound or one of its derivatives
            // Assert.That(result, Is.InstanceOf<Ok>());
        }
    }
}
