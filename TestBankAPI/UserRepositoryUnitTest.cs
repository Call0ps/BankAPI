﻿using BankAPI.Models;
using BankAPI.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestBankAPI
{
    partial class Tests
    {
        internal interface IUserRepo
        {
            public List<UserAccount> GetDatabase();

            public bool SaveUserAccount(UserAccount userAccount);
        }

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void CreateRepoAndUsers()
        {
            var service = new UASE();
            var expected = new List<UserAccount>()
            {
                new UserAccount(1, "asdfa@mail.com"),
                new UserAccount(2, "asdfa@mail.com"),
                new UserAccount(3, "asdfa@mail.com"),
                new UserAccount(4, "asdfa@mail.com"),
                new UserAccount(5, "asdfa@mail.com")
            };
            var actual = service.GetDataBase();
            Assert.AreEqual(expected, actual);
        }

        internal class HardcodedUserRepo : IUserRepo
        {
            public HardcodedUserRepo()
            {
                this.Database = new List<UserAccount>()
            {
                new UserAccount(1, "asdfa@mail.com"),
                new UserAccount(2, "asdfa@mail.com"),
                new UserAccount(3, "asdfa@mail.com"),
                new UserAccount(4, "asdfa@mail.com"),
                new UserAccount(5, "asdfa@mail.com")
            };
            }

            private List<UserAccount> Database { get; set; }

            public List<UserAccount> GetDatabase()
            {
                return this.Database;
            }

            public bool SaveUserAccount(UserAccount userAccount)
            {
                throw new System.NotImplementedException();
            }
        }

        internal class UASE : UserAccountService
        {
            public UASE()
            {
                this.MyRepp = new();
            }

            private HardcodedUserRepo MyRepp { get; set; }

            public List<UserAccount> GetDataBase()
            {
                return MyRepp.GetDatabase();
            }
        }
    }
}