using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectXamarin.Models
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public User() { }
        public User(string UserName, string Password)
        {
            this.userName = UserName;
            this.password = Password;
        }
        public bool CheckUserInformation()
        {
            if (this.userName.Equals("") && this.password.Equals(""))
                return false;
            else
                return true;
        }
    }
}
