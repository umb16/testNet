using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class User
    {
        public User()
        {

        }
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
            status = 0;
        }
        public string login;
        public string password;
        public int status;
    }

    public class Users
    {
        public List<User> usersList = new List<User>();
    }

