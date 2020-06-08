using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestProjectXamarin.Entity
{
    [Table( name:"User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        [DataType("int")]
        [Column("id")]
        public int id { get; set; }

        [Required]
        [DataType("nvarchar(30)")]
        [Column("UserName")]
        public string userName { get; set; }

        [Required]
        [DataType("nvarchar(30)")]
        [Column("Password")]
        public string password { get; set; }

        [DataType("int")]
        [Column("MobileNo")]
        public int? Number { set; get; }

        [Column("CreatedOnUtc")]
        public DateTime CreatedOnUtc { set; get; }
    }
}
