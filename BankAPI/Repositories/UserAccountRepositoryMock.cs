using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using BankAPI.Models;

namespace BankAPI.Repositories
{
    public class UserAccountRepositoryMock : IUserAccountRepository
    {
        public async Task<List<UserAccount>> All()
        {
            return new List<UserAccount>()
            {
                new UserAccount(1, "one@mail.com"),
                new UserAccount(2, "two@mail.com"),
                new UserAccount(3, "three@mail.com")
            };
        }

        public async Task<UserAccount> Get(int id)
        {
            return new UserAccount(id, "test@test.com");
        }

        public async Task<bool> Insert(UserAccount userAccount)
        {
            return true;
        }

        public async Task<bool> Remove(UserAccount userAccount)
        {
            return true;
        }
    }
}