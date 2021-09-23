using BankAPI.Models;

namespace BankAPI.Services
{
    public class UserAccountService
    {
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
    }
}