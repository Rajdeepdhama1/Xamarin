using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectXamarin.Entity;
using TestProjectXamarin.Models;
using TestProjectXamarin.Service;
using TestProjectXamarin.Data;
using TestProjectXamarin.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProjectXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly SampleContext _context;
        private readonly ILoginService login;
        public LoginPage(SampleContext context)
        {
            InitializeComponent();
            _context = context;
            login = new LoginService(context);
            Init();
        }

        async private void Btn_Signup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(_context));
        }
        void Init()
        {
            BackgroundColor = Constants.backgroundColor;
            Lbl_Username.TextColor = Constants.mainTextColor;
            Lbl_Password.TextColor = Constants.mainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            App.StartCheckInternet(Lbl_NoInternet, this);
            Btn_Signup.Clicked += Btn_Signup_Clicked;
            Btn_Signin.Clicked += SignInProcedure;
        }
        async void SignInProcedure(object sender, EventArgs e)
        {
            Users user = new Users(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckUserInformation())
            {
                //if (App.SettingsDatabase.GetSettings() == null)
                //{
                    //Settings settings = new Models.Settings();
                    //App.SettingsDatabase.SaveSettings(settings);
                //}
                var userDetails = login.GetUsers(user);
                //var result = await App.RestService.Login(user);
                if (userDetails != null)
                {
                    ActivitySpinner.IsVisible = true;
                    //App.UserDatabase.SaveUser(user);
                    //App.TokenDatabase.SaveToken(result);
                    await Navigation.PushAsync(new MasterDetail());
                }
                else
                {
                    await DisplayAlert("Login", "Invalid User", "Ok");
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