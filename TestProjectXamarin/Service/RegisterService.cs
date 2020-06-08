using System;
using System.Collections.Generic;
using System.Text;
using TestProjectXamarin.Entity;

namespace TestProjectXamarin.Service
{
    class RegisterService:IRegisterService
    {
        private SampleContext _sampleContext;
        public RegisterService(SampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public bool Register(User user)
        {
            bool status = false;
            try
            {
                _sampleContext.Users.Add(user);
                _sampleContext.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
            }
            return status;
        }
    }
}
