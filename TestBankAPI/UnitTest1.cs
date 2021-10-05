using BankAPI.Models;
using BankAPI.Services;
using BankAPI.Repositories;
using NUnit.Framework;

namespace TestBankAPI
{
    public partial class Tests
    {
        private HelloWorldService service = new();
        private UserAccountService uaService = new(new UserAccountRepositoryMock());

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HelloWorldTest()
        {
            Assert.IsTrue(service.HelloWorld() == "Hello World");
        }

        [Test]
        public void UserAccTest()
        {
            var user = new UserAccount(id: 1, email: "lidbom.calle@gmail.com");
            var result = uaService.CreateAccount(id: 1, email: "lidbom.calle@gmail.com");
            Assert.AreEqual(user, result);
        }
    }
}