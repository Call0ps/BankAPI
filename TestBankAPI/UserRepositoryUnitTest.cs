using BankAPI.Models;
using BankAPI.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestBankAPI
{
    partial class Tests
    {
        private UserAccountService _userAccountService { get; set; }

        [SetUp]
        public void SetUp ()
        {
            _userAccountService = new UserAccountService(new UserAccountRepositoryMock());
        }

        [Test]
        public void InsertAccount ()
        {
            Assert.IsFalse(_userAccountService.Insert(_userAccountService.CreateAccount(3, "mail.google@com.se")));
        }

        [Test]
        public void RemoveAccount ()
        {
            Assert.IsFalse(_userAccountService.Remove(10), message: "couldn't remove 10");
            Assert.IsTrue(_userAccountService.Remove(3), message: "couldn't remove 3");
        }
        [Test]
        public void ModifyAccount()
        {
            var changee = _userAccountService.Get(4);
            var emailChange = "mail.mail@mail.com";
            _userAccountService.ChangeEmail(changee, emailChange);
            System.Console.WriteLine("Hashcode {0}", changee.GetHashCode().ToString());
            var changed = _userAccountService.Get(4);
            Assert.AreEqual(emailChange, changed.Email, "Seems they didn't get a new email.");

        }
    }
}