using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProjectXamarin.Entity;
using TestProjectXamarin.Models;

namespace TestProjectXamarin.Service
{
    public class LoginService:ILoginService
    {
        private SampleContext _sampleContext;
        public LoginService(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public User GetUsers(Users user)
        {
            return _sampleContext.Users.
                Where(x => (x.userName == user.userName) && x.password == user.password)
                .FirstOrDefault();
        }
    }
}
