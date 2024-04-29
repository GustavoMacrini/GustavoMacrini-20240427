namespace GestaoColaboradores.Models.User
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public User() 
        {
            Id = Guid.NewGuid();
            Active = true;
        }

        public User(string login, string password)
        {
            Id = Guid.NewGuid();
            Active = true;
            Login = login;
            Password = password;
        }
    }
}
