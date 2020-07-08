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
            //var contactList = await App.Database.GetContactsAsync();
            //if (contactList.Count > 0)
            //{
            listView_contacts.ItemsSource = await App.Database.GetContactsAsync();
            //}

        }

        async void OnContactAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewContact
            {
                BindingContext = new Contact()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ContactDetails((Contact)e.SelectedItem));
            }
        }
    }
}