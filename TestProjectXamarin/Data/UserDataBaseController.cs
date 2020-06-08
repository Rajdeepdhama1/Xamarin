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
            database.CreateTable<Users>();
            var a = database.GetMapping<Users>();
            var b = database.GetTableInfo("User");
        }

        public Users GetUser()
        {
            lock (locker)
            {
                if(database.Table<Users>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Users>().First();
                }
            }
        }

        public int SaveUser(Users user)
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
                return database.Delete<Users>(id);
            }
        }
    }
}
