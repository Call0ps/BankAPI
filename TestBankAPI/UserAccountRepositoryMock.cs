using BankAPI.Models;
using BankAPI.Repositories;
using System.Collections.Generic;
using System;

namespace TestBankAPI
{
    partial class Tests
    {
        internal class UserAccountRepositoryMock : IUserAccountRepository
        {
            public UserAccountRepositoryMock ()
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

            List<UserAccount> IUserAccountRepository.All ()
            {
                return Repository;
            }

            bool IUserAccountRepository.Remove ( UserAccount userAccount )
            {
                return Repository.Remove(userAccount);
            }

            bool IUserAccountRepository.Insert ( UserAccount userAccount )
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

            UserAccount IUserAccountRepository.Get ( int id )
            {
                return Repository.Find(u => u.Id == id);
            }
        }
    }
}