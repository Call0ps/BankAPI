using System.Collections.Generic;
using BankAPI.Models;

namespace BankAPI.Repositories
{
    public interface IUserAccountRepository
    {
        public List<UserAccount> All();
        public bool Remove(UserAccount userAccount);

        public bool Insert(UserAccount userAccount);
        public UserAccount Get(int id);
    }
}