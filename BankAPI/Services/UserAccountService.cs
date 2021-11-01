using System;
using System.Collections.Generic;
using BankAPI.Models;
using BankAPI.Repositories;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<UserAccount> CreateAccount ( int id, string email )
        {
            return new UserAccount(id, email);
        }

        public async Task<List<UserAccount>> GetAll ()
        {
            return await Repository.All();
        }

        public async Task<bool> Insert ( UserAccount userAccount )
        {
            var accounts = await GetAll();
            return accounts.Find(u => u.Equals(userAccount)) == null && Repository.Insert(userAccount).Result;
        }

        public async Task<bool> ChangeEmail(int id, string emailChange)
        {
            var user = await GetUserAccount(id);
            return user?.SetNewEmail(emailChange) ?? false;
        }

        public async Task<UserAccount> Get(int id) => await GetUserAccount(id);
        public async Task<bool> Remove ( int id ) => await Repository.Remove(await GetUserAccount(id));

        private async Task<UserAccount> GetUserAccount ( int id ) => await Repository.Get(id);
    }
}