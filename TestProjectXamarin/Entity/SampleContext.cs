using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestProjectXamarin.Entity
{
    public class SampleContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public SampleContext()
        {
            this.Database.OpenConnection();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string dbPath = string.Empty;
            dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TestDB.db3");
            optionBuilder.UseSqlite($"Filename={dbPath}");
        }

    }
}
