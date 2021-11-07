using System;
using System.Collections.Generic;
using BankAPI.Models;
using BankAPI.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Services
{
    public class UserService
    {
        public UserService ( IUserRepository repository )
        {
            Repository = repository;
        }

        private IUserRepository Repository { get; }

        /// <summary>
        /// Creates a user 
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <param name="email">User email</param>
        /// <returns>Created User object</returns>
        public async Task<User> Create ( int id, string email )
        {
            return new User(id, email);
        }

        public async Task<List<User>> GetAll ()
        {
            return await Repository.All();
        }

        public async Task<bool> Insert ( User user )
        {
            var s = await GetAll();
            return s.Find(u => u.Equals(user)) == null && Repository.Insert(user).Result;
        }

        public async Task<bool> ChangeEmail(int id, string emailChange)
        {
            var user = await GetUser(id);
            return user?.SetNewEmail(emailChange) ?? false;
        }

        public async Task<User> Get(int id) => await GetUser(id);
        public async Task<bool> Remove ( int id ) => await Repository.Remove(await GetUser(id));

        private async Task<User> GetUser ( int id ) => await Repository.Get(id);
    }
}