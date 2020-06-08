using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestProjectXamarin.Data;
using TestProjectXamarin.Entity;
using TestProjectXamarin.Models;
using TestProjectXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProjectXamarin
{
    public partial class App : Application
    {
        static TokenDataBaseController tokenDatabase;
        static UserDataBaseController userDatabase;
        static SettingsDataBaseController settingsDatabase;
        static RestService restService;
        private static Label labelScreen;
        private static bool hasInternet;
        public static Page CurrentPage;
        public static Timer timer;
        private static bool noInterShow;
        public App(SampleContext context)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage(context));
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

        public static SettingsDataBaseController SettingsDatabase
        {
            get
            {
                if (settingsDatabase == null)
                {
                    settingsDatabase = new SettingsDataBaseController();
                }
                return settingsDatabase;
            }
        }

        public static RestService RestService
        {
            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
        }

        //*********Internet Connection***********//

        public static void StartCheckInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constants.NoInternetText;
            label.IsVisible = false;
            hasInternet = true;
            CurrentPage = page;
            if(timer == null)
            {
            timer = new Timer((e) =>
            {
              CheckIfInternetOverTime();
             }, null, 10, (int)TimeSpan.FromSeconds(2).TotalMilliseconds);
            }
        }

        private static void CheckIfInternetOverTime()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if(!networkConnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await ShowDisplayAlert();
                        }
                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasInternet = true;
                    labelScreen.IsVisible = false;
                });
            }
        }

     
        private static async Task ShowDisplayAlert()
        {
            noInterShow = false;
            await CurrentPage.DisplayAlert("Internet", "Device has no internet, please Reconnect", "OK");
        }
    }
}
