using System;
using System.Collections.Generic;
using BankAPI.Models;
using BankAPI.Repositories;
using System.Linq;

namespace BankAPI.Services
{
    public class UserAccountService
    {
        public UserAccountService ( IUserAccountRepository repository )
        {
            Repository = repository;
        }

        private IUserAccountRepository Repository { get; set; }

        /// <summary>
        /// Creates a user account
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <param name="email">User email</param>
        /// <returns>Created UserAccount object</returns>
        public UserAccount CreateAccount ( int id, string email )
        {
            return new UserAccount(id, email);
        }

        public List<UserAccount> GetAll ()
        {
            return Repository.All();
        }

        public bool Insert ( UserAccount userAccount )
        {
            var accounts = GetAll();
            return accounts.Find(u => u.Equals(userAccount)) == null && Repository.Insert(userAccount);
        }

        public bool ChangeEmail(int id, string emailChange)
        {
            var user = GetUserAccount(id);
            return user?.SetNewEmail(emailChange) ?? false;
        }

        public UserAccount Get(int id) => GetUserAccount(id);

        public bool Remove ( int id ) => Repository.Remove(GetUserAccount(id));

        private UserAccount GetUserAccount ( int id ) => Repository.Get(id);
    }
}