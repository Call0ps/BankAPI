using System.Collections.Generic;
using System.Threading.Tasks;
using BankAPI.Models;

namespace BankAPI.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> All();
        public Task<bool> Remove(User user);

        public Task<bool> Insert(User user);
        public Task<User> Get(int id);
    }
}