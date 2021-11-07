using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using BankAPI.Models;

namespace BankAPI.Repositories
{
    public class UserRepositoryMock : IUserRepository
    {
        public async Task<List<User>> All()
        {
            return new List<User>()
            {
                new User(1, "one@mail.com"),
                new User(2, "two@mail.com"),
                new User(3, "three@mail.com")
            };
        }

        public async Task<User> Get(int id)
        {
            return new User(id, "test@test.com");
        }

        public async Task<bool> Insert(User user)
        {
            return true;
        }

        public async Task<bool> Remove(User user)
        {
            return true;
        }
    }
}