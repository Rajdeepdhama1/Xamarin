using System;
using System.Collections.Generic;
using System.Text;
using TestProjectXamarin.Entity;

namespace TestProjectXamarin.Service
{
    public interface ILoginService
    {
        User GetUsers(User user);
    }
}
