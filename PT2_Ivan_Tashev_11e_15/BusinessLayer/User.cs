
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [Required, Range(18, 81)]
        public int? Age { get; set; }

        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required, MaxLength(70)]
        public string Password { get; set; }

        [Required, MaxLength(20)]
        public string Email { get; set; }

        public List<User> Friends { get; set; } = new List<User>();
        public List<Interest> Interests { get; set; }= new List<Interest>();

        private User() 
        {

        }
        public User(string firstName, string lastName, int age, string username, string password, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
