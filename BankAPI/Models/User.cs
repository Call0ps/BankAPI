namespace BankAPI.Models
{
    public class User
    {
        public User(int id, string email)
        {
            this.Id = id;
            this.Email = email;
        }

        public int Id { get; init; }
        public string Email { get; private set; }
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