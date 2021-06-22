using Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    public class User : IInfo
    {
        public User()
        {
            Admins = new HashSet<Admin>();
            Divers = new HashSet<Diver>();
        }

        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Diver> Divers { get; set; }
        protected User(string login, string password, int type)
        {
            Login = login;
            Password = password;
            UserType = type;
        }
        public virtual void GetInfo()
        {

        }
    }
}
