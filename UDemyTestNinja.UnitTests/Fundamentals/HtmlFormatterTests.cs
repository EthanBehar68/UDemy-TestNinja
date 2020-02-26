

using NUnit.Framework;
using TestNinja.Fundamentals;

namespace UDemyTestNinja.UnitTests
{
    [TestFixture]
    class HtmlFormatterTests
    {

        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");

            // Specific - 
            // future iterations can break tests so don't make them too specific
             Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            // General -
            // likewise if too general tests can pass while code is broken ie just test for first strong
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain("abc").IgnoreCase);
        }
    }
}
