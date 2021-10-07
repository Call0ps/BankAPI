namespace BankAPI.Models
{
    public class UserAccount
    {
        private int id;
        private string email;

        public UserAccount ( int id, string email )
        {
            this.Id = id;
            this.Email = email;
        }

        public int Id { get => id; init => id = value; }
        public string Email { get => email; private set => email = value; }

        public override bool Equals ( object obj )
        {
            var other = obj as UserAccount;
            return this.Id == other.Id;
        }

        public override int GetHashCode ()
        {
            return Id.GetHashCode();
        }
    }
}