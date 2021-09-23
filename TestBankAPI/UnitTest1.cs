using NUnit.Framework;
using BankAPI.Services;

namespace TestBankAPI
{
    public class Tests
    {
        private HelloWorldService service = new();
        private UserAccountService uaService = new();

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

    internal class UserAccountService
    {
        internal UserAccount CreateAccount(int id, string email)
        {
            return new UserAccount(id, email);
        }
    }

    internal class UserAccount
    {
        private int id;
        private string email;

        public UserAccount(int id, string email)
        {
            this.id = id;
            this.email = email;
        }

        public override bool Equals(object obj)
        {
            var other = obj as UserAccount;
            return this.id == other.id && this.email == other.email;
        }
    }
}