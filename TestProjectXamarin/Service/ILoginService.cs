﻿using System;
using System.Collections.Generic;
using System.Text;
using TestProjectXamarin.Entity;
using TestProjectXamarin.Models;

namespace TestProjectXamarin.Service
{
    public interface ILoginService
    {
        User GetUsers(Users user);
    }
}
