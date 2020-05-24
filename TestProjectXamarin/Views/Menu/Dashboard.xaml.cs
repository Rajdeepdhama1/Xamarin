using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectXamarin.Models;
using TestProjectXamarin.Views.DetailView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProjectXamarin.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.backgroundColor;
            App.StartCheckInternet(Lbl_NoInternet, this);
        }

        async void SelectedScreen1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoScreen1());
        }
    }
}