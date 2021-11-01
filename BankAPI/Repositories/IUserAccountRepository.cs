using System.Collections.Generic;
using System.Threading.Tasks;
using BankAPI.Models;

namespace BankAPI.Repositories
{
    public interface IUserAccountRepository
    {
        public Task<List<UserAccount>> All();
        public Task<bool> Remove(UserAccount userAccount);

        public Task<bool> Insert(UserAccount userAccount);
        public Task<UserAccount> Get(int id);
    }
}