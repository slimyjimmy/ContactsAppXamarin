using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFlutter.Models;

namespace XamarinFlutter.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactEdit : ContentPage
    {
        public Contact Contact {get; set;}

        public ContactEdit(Contact contact)
        {
            Contact = contact;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Editor_Name.Text = Contact.Name;
            Editor_Number.Text = Contact.Number;
        }

        protected async void OnEditContactClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Editor_Name.Text))
            {
                Contact.Name = Editor_Name.Text;
                Contact.Number = Editor_Number.Text;
                await App.Database.SaveContactAsync(Contact);
                await Navigation.PopAsync();
            }
        }

        protected async void OnCameraButtonClicked(object sender, EventArgs e)
        {
            var test = await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
            Contact.PathToPhoto = file.Path.ToString();
        }
    }
}