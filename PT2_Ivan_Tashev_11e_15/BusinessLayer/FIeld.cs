using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Field
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        
        private Field()
        {

        }
        public Field(string name)
        {
            Name = name;
        }
    }
}
