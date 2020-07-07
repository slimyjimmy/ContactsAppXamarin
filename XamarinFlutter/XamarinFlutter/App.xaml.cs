using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFlutter.Data;
using XamarinFlutter.Pages;

namespace XamarinFlutter
{
    public partial class App : Application
    {
        private static ContactsDatabase database;

        public static ContactsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ContactsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Contacts.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactsOverview());
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
    }
}
