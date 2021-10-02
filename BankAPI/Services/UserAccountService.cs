using System.Collections.Generic;
using BankAPI.Models;
using BankAPI.Repositories;

namespace BankAPI.Services
{
    public class UserAccountService
    {
        public UserAccountService(IUserRepository repository)
        {
            this.UserRepository = repository;
        }

        private IUserRepository UserRepository { get; set; }

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
        public List<UserAccount> GetDataBase()
        {
            return UserRepository.GetDatabase();
        }
    }
}
