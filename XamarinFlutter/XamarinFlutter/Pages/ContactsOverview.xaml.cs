using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using XamarinFlutter.Models;

namespace XamarinFlutter.Pages
{
    public partial class ContactsOverview : ContentPage
    {
        public ContactsOverview()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView_contacts.ItemsSource = await App.Database.GetContactsAsync();
        }

        async void OnContactAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewContact
            {
                BindingContext = new Contact()
            });
        }

        async void OnListViewItemSelected(object sender, EventArgs e)
        {

        }
    }
}