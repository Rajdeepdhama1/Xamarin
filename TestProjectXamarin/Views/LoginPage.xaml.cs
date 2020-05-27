using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectXamarin.Models;
using TestProjectXamarin.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProjectXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            BackgroundColor = Constants.backgroundColor;
            Lbl_Username.TextColor = Constants.mainTextColor;
            Lbl_Password.TextColor = Constants.mainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            App.StartCheckInternet(Lbl_NoInternet, this);
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }
        async void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckUserInformation())
            {
                if (App.SettingsDatabase.GetSettings() == null)
                {
                    Settings settings = new Models.Settings();
                    App.SettingsDatabase.SaveSettings(settings);
                }
                var result = await App.RestService.Login(user);
                if (result.token != null)
                {
                    ActivitySpinner.IsVisible = true;
                    App.UserDatabase.SaveUser(user);
                    App.TokenDatabase.SaveToken(result);
                    Application.Current.MainPage = new MasterDetail();
                }
            }
            else
            {
                await DisplayAlert("Login", "Login Not Correct, empty username or password", "Ok");
                ActivitySpinner.IsVisible = false;
            }
        }
    }
}