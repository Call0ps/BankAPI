namespace BankAPI.Models
{
    public class UserAccount
    {
        private int id;
        private string email;

        public UserAccount(int id, string email)
        {
            this.id = id;
            this.email = email;
        }

        public override bool Equals(object obj)
        {
            var other = obj as UserAccount;
            return this.id == other.id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode() ^ email.GetHashCode();
        }
    }
}