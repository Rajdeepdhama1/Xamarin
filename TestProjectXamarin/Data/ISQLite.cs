﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectXamarin.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
