using System.Collections.Generic;
using System.Net.Mail;
using BankAPI.Models;

namespace BankAPI.Repositories
{
    internal class UserAccountRepositoryMock : IUserAccountRepository
    {
        public List<UserAccount> All()
        {
            return new List<UserAccount>()
            {
                new UserAccount(1, "one@mail.com"),
                new UserAccount(2, "two@mail.com"),
                new UserAccount(3, "three@mail.com")
            };
        }

        public UserAccount Get(int id)
        {
            return new UserAccount(id, "test@test.com");
        }

        public bool Insert(UserAccount userAccount)
        {
            return true;
        }

        public bool Remove(UserAccount userAccount)
        {
            return true;
        }
    }
}