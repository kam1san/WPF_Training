using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersDesktopApp
{
    class User
    {
        public int id { get; set; }
        private string login;
        private string password;
        private string email;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public User(){}

        public User(string log, string pass, string mail)
        {
            this.login = log;
            this.password = pass;
            this.email = mail;
        }
    }
}
