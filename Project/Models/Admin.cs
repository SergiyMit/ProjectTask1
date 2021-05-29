using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    public class Admin : User
    {
        private readonly int IdAdmin;
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PersonalAccessCode { get; set; }

        public Admin(string name, string surname, int personalaccesscode, string login, string password) : base(login, password, 2)
        {
            Name = name;
            Surname = surname;
            PersonalAccessCode = personalaccesscode;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Name: {this.Name}| Surname: {this.Surname}");
        }
    }
}
