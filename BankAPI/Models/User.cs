using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BankAPI.Models
{
    public class User : IdentityUser
    {
        #pragma warning disable
        public List<Account> Accounts { get; set; }
        public User(string email):base(email)
        {
        }
        public bool SetNewEmail(string email)
        {
            if (this.Email == email)
            {
                throw new System.Exception("Email is the same as before");
            }
            else
            {
                this.Email = email;
                return true;
            }
        }

        public override bool Equals(object? obj)
        {
            var other = obj as User;
            return Id == other?.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}