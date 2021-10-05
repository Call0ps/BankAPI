using BankAPI.Models;
using BankAPI.Services;
using BankAPI.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TestBankAPI
{
    partial class Tests
    {
        private UserAccountService _userAccountService { get; set; }
        [SetUp]
        public void SetUp()
        {
            _userAccountService = new UserAccountService(new UserAccountRepositoryMock());
        }

        [Test]
        public void CreateRepoAndUsers()
        {
            var expected = new List<UserAccount>()
            {
                new UserAccount(1, "asdfa@mail.com"),
                new UserAccount(2, "asdfa@mail.com"),
                new UserAccount(3, "asdfa@mail.com"),
                new UserAccount(4, "asdfa@mail.com"),
                new UserAccount(5, "asdfa@mail.com")
            };
            var actual = _userAccountService.GetAll();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void InsertAccount()
        {
            Assert.IsFalse(_userAccountService.Insert(_userAccountService.CreateAccount(3, "mail.google@com.se")));
        }
        [Test]
        public void RemoveAccount ()
        {
            Assert.IsTrue(_userAccountService.Remove(3));
            Assert.IsFalse(_userAccountService.Remove(10));
        }
        internal class UserAccountRepositoryMock : IUserRepository
        {
            public UserAccountRepositoryMock()
            {
                this.Repository = new List<UserAccount>() {
                new UserAccount(1, "asdfa@mail.com"),
                new UserAccount(2, "asdfa@mail.com"),
                new UserAccount(3, "asdfa@mail.com"),
                new UserAccount(4, "asdfa@mail.com"),
                new UserAccount(5, "asdfa@mail.com")
                };
            }
            private List<UserAccount> Repository { get; set; }
            List<UserAccount> IUserRepository.All()
            {
                return Repository;
            }
            bool IUserRepository.Remove(UserAccount userAccount)
            {
                return Repository.Remove(userAccount);
            }
            bool IUserRepository.Insert(UserAccount userAccount)
            {
                try
                {
                    Repository.Add(userAccount);
                    return true;
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    return false;
                }
            }
            UserAccount IUserRepository.Get(int id )
            {
                return Repository.Find(u => u.GetHashCode() == id.GetHashCode());
            }
        }
    }
}