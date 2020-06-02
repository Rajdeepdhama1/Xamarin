using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProjectXamarin.Views.DetailView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsList : ContentPage
    {
        List<ListViewItem> Items;
        public ItemsList()
        {
            InitializeComponent();
            initList();
        }

        void initList()
        {
            Items = new List<ListViewItem>();
            Items.Add(new ListViewItem() { Name = "Test1", Value = 1, Text = "This is Item 1" });
            Items.Add(new ListViewItem() { Name = "Test2", Value = 2, Text = "This is Item 2" });
            Items.Add(new ListViewItem() { Name = "Test3", Value = 3, Text = "This is Item 3" });
            exampleListView.ItemsSource = Items;
            exampleListView.ItemTapped += ExampleListView_ItemTapped;
        }

        private void ExampleListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListViewItem item = (ListViewItem)e.Item;
            Navigation.PushAsync(new ItemDetails(item));
        }
    }
}