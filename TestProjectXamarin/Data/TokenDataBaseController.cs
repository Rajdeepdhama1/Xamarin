﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TestProjectXamarin.Models;
using Xamarin.Forms;

namespace TestProjectXamarin.Data
{
    public class TokenDataBaseController
    {
        static object locker = new object();
        SQLiteConnection database;
        public TokenDataBaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
        }

        public Token GetToken()
        {
            lock (locker)
            {
                if(database.Table<Token>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Token>().First();
                }
            }
        }

        public int SaveToken(Token token)
        {
            lock (locker)
            {
                if ( token.id != 0)
                {
                    database.Update(token);
                    return token.id;
                }
                else
                {
                    return database.Insert(token);
                }
            }
        }

        public int DeleteToken( int id)
        {
            lock (locker)
            {
                return database.Delete<Token>(id);
            }
        }
    }
}
