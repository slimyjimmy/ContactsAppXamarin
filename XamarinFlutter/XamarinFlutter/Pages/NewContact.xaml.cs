using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFlutter.Models;

namespace XamarinFlutter.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewContact : ContentPage
    {
        private string pathToPhoto;
        public NewContact()
        {
            InitializeComponent();
        }

        async void OnInsertContactClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Editor_Name.Text))
            {
                await App.Database.SaveContactAsync(new Contact
                {
                    PathToPhoto = pathToPhoto,
                    Name = Editor_Name.Text,
                    Number = Editor_Number.Text
                });
            }
            await Navigation.PopAsync();
        }

        async void OnCameraButtonClicked(object sender, EventArgs e)
        {
            var test = await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
            pathToPhoto = file.Path.ToString();
        }
    }
}