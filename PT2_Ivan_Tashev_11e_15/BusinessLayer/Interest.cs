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

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();

        public Field Field { get; set; }

        private Interest() 
        {
            
        }

        public Interest(string name)
        {
            Name = name;
        }
    }
}
