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
    public partial class NewContact : ContentPage
    {
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
                    Name = Editor_Name.Text,
                    Number = Editor_Number.Text
                });
            }
            await Navigation.PopAsync();
        }

        void OnCameraButtonClicked(object sender, EventArgs e)
        {

        }
    }
}