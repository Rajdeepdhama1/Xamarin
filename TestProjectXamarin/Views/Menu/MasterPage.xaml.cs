﻿using System;
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
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> Items;
        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }

        void SetItems()
        {
            Items = new List<MasterMenuItem>();
            Items.Add(new MasterMenuItem("InfoScreen1", "LoginIcon.jpg", Color.White, typeof(InfoScreen1)));
            Items.Add(new MasterMenuItem("InfoScreen2", "LoginIcon.jpg", Color.White, typeof(InfoScreen2)));
            ListView.ItemsSource = Items;
        }
    }
}