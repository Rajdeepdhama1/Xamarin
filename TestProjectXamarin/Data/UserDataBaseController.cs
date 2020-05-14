using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TestProjectXamarin.Models;
using Xamarin.Forms;

namespace TestProjectXamarin.Data
{
    public class UserDataBaseController
    {
        static object locker = new object();
        SQLiteConnection database;
        public UserDataBaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
            var a = database.GetMapping<User>();
            var b = database.GetTableInfo("User");
        }

        public User GetUser()
        {
            lock (locker)
            {
                if(database.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().First();
                }
            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                if ( user.id != 0)
                {
                    database.Update(user);
                    return user.id;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }

        public int DeleteUser( int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
