using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace UDemyTestNinja.UnitTests.Mocking
{
    [TestFixture]
    class OrderServiceTests
    {

        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);

            var order = new Order();
            service.PlaceOrder(order);

            // Use to test interaction between two classes
            storage.Verify(s => s.Store(order));
        }
    }
}
