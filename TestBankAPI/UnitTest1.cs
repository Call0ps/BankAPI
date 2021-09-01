using NUnit.Framework;
using BankAPI.Services;

namespace TestBankAPI
{
    public class Tests
    {
        private HelloWorldService service = new();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HelloWorldTest()
        {
            Assert.IsTrue(service.HelloWorld() == "Hello World");
        }
    }
}