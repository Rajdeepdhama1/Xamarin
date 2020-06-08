using System;
using System.Collections.Generic;
using System.Text;
using TestProjectXamarin.Entity;
using TestProjectXamarin.Service;
using TestProjectXamarin.Views;
using Xamarin.Forms;

namespace TestProjectXamarin.Models
{
    public class RegisterViewModel
    {
        public INavigation _navigation;
        private readonly SampleContext _context;
        private readonly IRegisterService _register;
        public RegisterViewModel(INavigation navigation, SampleContext context)
        {
            _navigation = navigation;
            _context = context;
            _register = new RegisterService(context);
            SignUpCommand = new Command(Register);
            LoginCommand = new Command(SignInPage);
        }

        public string Name { set; get; }
        public string Password { set; get; }
        public int? Number { set; get; }
        public Command SignUpCommand { get; }
        public Command LoginCommand { get; }

        public void Register()
        {
            User user = new User();
            user.userName = Name;
            user.password = Password;
            user.Number = Number;
            user.CreatedOnUtc = DateTime.UtcNow;

            var status = _register.Register(user);
            if (status)
            {
                _navigation.PushAsync(new LoginPage(_context));
            }
            else
            {

            }

        }

        private void SignInPage(object obj)
        {
            _navigation.PushAsync(new LoginPage(_context));
        }
    }
}
