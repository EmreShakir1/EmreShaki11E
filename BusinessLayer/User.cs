using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string SecondName { get; set; }

        [Required]
        [Range(18,81)]
        public int Age { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(70)]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string Email { get; set; }


        public List<User> Friends { get; set; }

        public List<Interest> Interests { get; set; }

        private User()
        {
            Friends = new List<User>();
            Interests = new List<Interest>();
        }
        public User(string firstName,string secondName,int age,string username,string password,string email)
        {
            FirstName = firstName;
            SecondName = secondName;
            Age = age;
            Username = username;
            Password = password;
            Email = email;
            Friends = new List<User>();
            Interests = new List<Interest>();
        }



    }
}
