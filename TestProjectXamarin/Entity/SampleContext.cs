using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestProjectXamarin.Entity
{
    public class SampleContext: DbContext
    {
        private readonly string _databasePath;
        public DbSet<User> Users { get; set; }
        public SampleContext(string databasePath)
        {
            _databasePath = databasePath;
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Filename={_databasePath}");
        }

    }
}
