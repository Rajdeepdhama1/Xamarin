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
        Dictionary<string, Color> NamesToColor = new Dictionary<string, Color>
        {
            {"Aqua" ,Color.Aqua}, {"Black",Color.Black },
            {"Blue",Color.Blue}, {"Green",Color.Green},
            {"Gray",Color.Gray}, {"Yellow",Color.Yellow},
            {"White",Color.White}, {"Violet",Color.Violet},
            {"Pink",Color.Pink}, {"Red",Color.Red},
            {"Purple",Color.Purple}, {"Orange",Color.Orange}
        };
        public ItemsList()
        {
            InitializeComponent();
            initList();
            initSearchBar();
            initPicker();
            GetDateTime();
        }

        void GetDateTime()
        {
            DateTime date = DatePickerT.Date;
            DatePickerT.DateSelected += DatePickerT_DateSelected;

        }

        private void DatePickerT_DateSelected(object sender, DateChangedEventArgs e)
        {
            DisplayAlert("Title", "Date Selected: " + e.NewDate, "Cancel");
        }

        void initPicker()
        {
            foreach(string color in NamesToColor.Keys)
            {
                picker.Items.Add(color);
            }
            picker.SelectedIndexChanged += (s, e) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    boxview.Color = Color.Default;
                }
                else
                {
                    string colortemp = picker.SelectedItem.ToString();
                    boxview.Color = NamesToColor[colortemp];
                }
            };
        }

        void initSearchBar()
        {
            sb_Search.TextChanged += (s, e) => FilterSearch(sb_Search.Text);
        }

        private void FilterSearch(string filter)
        {
            exampleListView.BeginRefresh();
            if (string.IsNullOrEmpty(filter))
            {
                exampleListView.ItemsSource = Items;
            }
            else
            {
                exampleListView.ItemsSource = Items.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
            }
            exampleListView.EndRefresh();
        }

        void initList()
        {
            Items = new List<ListViewItem>();
            Items.Add(new ListViewItem() { Name = "Book", Value = 2, Text = "This is Item 1" });
            Items.Add(new ListViewItem() { Name = "Pencil", Value = 6, Text = "This is Item 2" });
            Items.Add(new ListViewItem() { Name = "Eraser", Value = 3, Text = "This is Item 3" });
            exampleListView.ItemsSource = Items;
            exampleListView.ItemTapped += ExampleListView_ItemTapped;
        }

        private void ExampleListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListViewItem item = (ListViewItem)e.Item;
            Navigation.PushAsync(new ItemDetails(item));
        }

        void CancelClicked(Object sender,EventArgs e)
        {
            DisplayAlert("Toolbar", "Cancel button", "OK");
        }

        void SaveClicked(Object sender, EventArgs e)
        {
            DisplayAlert("Toolbar", "Save button", "OK");
        }
    }
}