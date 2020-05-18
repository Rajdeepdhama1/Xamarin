using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectXamarin.Models
{
    public class Token
    {
        [PrimaryKey]
        public int id { get; set; }
        public string token { get; set; }
        public string error_description { get; set; }
        public DateTime expire_date { get; set; }
        public int expire_in { get; set; }
        public Token() { }

    }
}
