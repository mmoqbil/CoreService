namespace CoreService_backend.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }

        private static int _nextId = 0;
        public User(string email, string name, string password, string passwordConfirmation)
        {
            Email = email;
            Name = name;
            Password = password;
            PasswordConfirmation = passwordConfirmation;
            Id = Interlocked.Increment(ref _nextId);
        }
    }
}
