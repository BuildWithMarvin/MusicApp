
namespace MusicApp2
{
    public class User
    {
        private Guid id;
        private string email;
        private string password;
     


        public Guid Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public User(string pEmail, string pPW)
        {
            email = pEmail;
            password = pPW;
        }

        public User(Guid pID, string pEmail, string pPW)
        { 
            id = pID;
            email = pEmail;
            password = pPW;
        }
    }
}
