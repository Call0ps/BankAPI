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
            this.Repository = repository;
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
            return accounts.Find(u => u.Equals(userAccount)) != null ? false : Repository.Insert(userAccount);
        }

        public void ChangeEmail(UserAccount changee, string emailChange)
        {
            var user = Repository.All().Where(u => u.Equals(changee)).SingleOrDefault();
            user.SetNewEmail(emailChange);
        }

        public UserAccount Get(int v)
        {
            return Repository.Get(v);
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