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
        private int IdUser;
        public string Login { get; set; }
        public string Password { private get; set; }
        private readonly int UserType;
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
