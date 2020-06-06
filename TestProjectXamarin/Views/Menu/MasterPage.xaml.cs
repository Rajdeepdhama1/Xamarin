using System;
using System.Collections.Generic;
using System.Drawing;
using TestProjectXamarin.Models;
using TestProjectXamarin.Views.DetailView;
using TestProjectXamarin.Views.DetailView.SettingsView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProjectXamarin.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> Items;
        public MasterPage()
        {
            InitializeComponent();
            SetItems();
            Logout_btn.Clicked += Logout_btn_Clicked;
        }

        private void Logout_btn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("LogOut", "LogOut Successfully", "Ok");
            Application.Current.MainPage = new LoginPage();
        }

        void SetItems()
        {
            Items = new List<MasterMenuItem>();
            Items.Add(new MasterMenuItem("InfoScreen1", "LoginIcon.jpg", System.Drawing.Color.White, typeof(InfoScreen1)));
            Items.Add(new MasterMenuItem("InfoScreen2", "LoginIcon.jpg", System.Drawing.Color.White, typeof(InfoScreen2)));
            Items.Add(new MasterMenuItem("Settings", "LoginIcon.jpg", System.Drawing.Color.White, typeof(SettingsScreen)));
            Items.Add(new MasterMenuItem("Items", "LoginIcon.jpg", System.Drawing.Color.White, typeof(ItemsList)));
            Items.Add(new MasterMenuItem("Pie-Chart", "LoginIcon.jpg", System.Drawing.Color.White, typeof(OxyPlotView)));
            ListView.ItemsSource = Items;
        }
    }
}