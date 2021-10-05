using System;
using System.Collections.Generic;
using BankAPI.Models;
using BankAPI.Repositories;
using System.Linq;

namespace BankAPI.Services
{
    public class UserAccountService
    {
        public UserAccountService(IUserRepository repository)
        {
            this.Repository = repository;
        }

        private IUserRepository Repository { get; set; }

        /// <summary>
        /// Creates a user account
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <param name="email">User email</param>
        /// <returns>Created UserAccount object</returns>
        public UserAccount CreateAccount(int id, string email)
        {
            return new UserAccount(id, email);
        }
        public List<UserAccount> GetAll()
        {
            return Repository.All();
        }
        public bool Insert(UserAccount userAccount)
        {
            var accounts = GetAll();
            return accounts.Find(u => u.Equals(userAccount)) != null ? false : Repository.Insert(userAccount);
        }

        public bool Remove ( int v )
        {
            return Repository.Remove(GetUserAccount(v));
        }

        private UserAccount GetUserAccount ( int v )
        {
            return Repository.Get(v);

        }
    }
}
