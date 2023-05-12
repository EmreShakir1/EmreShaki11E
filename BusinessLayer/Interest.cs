using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public List<User> Users { get; set; }

        public Region? Region { get; set; }

        private Interest()
        {
            Users = new List<User>();
        }

        public Interest(string name, Region? region = null)
        {
            Name = name;
            Users = new List<User>();
            Region = region;
        }

    }
}
