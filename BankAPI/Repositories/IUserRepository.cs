using System.Collections.Generic;
using BankAPI.Models;

namespace BankAPI.Repositories
{
    public interface IUserRepository
    {
        public List<UserAccount> GetDatabase();

        public bool SaveUserAccount(UserAccount userAccount);
    }
}