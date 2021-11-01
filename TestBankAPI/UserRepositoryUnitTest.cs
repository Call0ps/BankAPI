using BankAPI.Models;
using BankAPI.Services;
using NUnit.Framework;
using BankAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            Assert.IsFalse(_userAccountService.Insert(_userAccountService.CreateAccount(3, "mail.google@com.se").Result).Result);
        }

        [Test]
        public async Task RemoveAccount ()
        {
            var removeTen = await _userAccountService.Remove(10);
            var removeThree = await _userAccountService.Remove(3);
            Assert.IsFalse(removeTen, message: "couldn't remove 10");
            Assert.IsTrue(removeThree, message: "couldn't remove 3");
        }
        [Test]
        public async Task ModifyAccount()
        {
            var changee = await _userAccountService.Get(4);
            var emailChange = "mail.mail@mail.com";
            await _userAccountService.ChangeEmail(changee.Id, emailChange);
            System.Console.WriteLine("Hashcode {0}", changee.GetHashCode().ToString());
            var changed = await _userAccountService.Get(4);
            Assert.AreEqual(emailChange, changed.Email, "Seems they didn't get a new email.");

        }
    }
}