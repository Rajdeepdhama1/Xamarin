using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectXamarin.Models
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public Users() { }
        public Users(string UserName, string Password)
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
