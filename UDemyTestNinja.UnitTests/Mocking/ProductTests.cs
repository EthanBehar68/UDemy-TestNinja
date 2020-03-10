using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDemyTestNinja.Mocking;

namespace UDemyTestNinja.UnitTests.Mocking
{
    [TestFixture]
    class ProductTests
    {

        [Test]
        public void _GetPrice_GoldCustomer_Apply30PercentDiscount() // Ideal unit test (3-5-10 lines per test)
        {
            var product = new Product { ListPrice = 100 };

            var result = product.GetPrice(new Customer { IsGold = true });

            Assert.That(result, Is.EqualTo(70));
        }

        public void _GetPrice_GoldCustomer_Apply30PercentDiscount2() // Example of over moq-ing
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(c => c.IsGold).Returns(true);

            var product = new Product { ListPrice = 100 };
            
            var result = product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(70));
        }
    }
}
