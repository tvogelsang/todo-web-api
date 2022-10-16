namespace TodoWebApi.Entity
{
    public class User
    {
        public User(string email)
        {
            Email = email;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Email { get; set; }
    }
}
