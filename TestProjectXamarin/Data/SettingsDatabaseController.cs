using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TestProjectXamarin.Models;
using Xamarin.Forms;

namespace TestProjectXamarin.Data
{
    public class SettingsDataBaseController
    {
        static object locker = new object();
        SQLiteConnection database;
        public SettingsDataBaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Settings>();
        }
        public Settings GetSettings()
        {
            lock (locker)
            {
                if (database.Table<Settings>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Settings>().First();
                }
            }
        }

        public int SaveSettings(Settings settings)
        {
            lock (locker)
            {
                if (settings.id != 0)
                {
                    database.Update(settings);
                    return settings.id;
                }
                else
                {
                    settings.id = 1;
                    return database.Insert(settings);
                }
            }
        }
    }
}
