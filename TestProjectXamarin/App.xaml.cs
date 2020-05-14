using System;
using TestProjectXamarin.Data;
using TestProjectXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProjectXamarin
{
    public partial class App : Application
    {
        static TokenDataBaseController tokenDatabase;
        static UserDataBaseController userDatabase;
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static UserDataBaseController UserDatabase
        {
            get
            {
                if(userDatabase == null)
                {
                    userDatabase = new UserDataBaseController();
                }
                return userDatabase;
            }
        }

        public static TokenDataBaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDataBaseController();
                }
                return tokenDatabase;
            }
        }
    }
}
