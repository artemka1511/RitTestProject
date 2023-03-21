using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectRIT.Objects
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string Surname { get; set; }

        public User(string? name, int age, string surname)
        {
            Name = name;
            Age = age;
            Surname = surname;
        }
    }
}
