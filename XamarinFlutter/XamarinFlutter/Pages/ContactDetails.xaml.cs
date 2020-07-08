using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFlutter.Models;

namespace XamarinFlutter.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetails : ContentPage
    {
        public Contact Contact { get; set; }


        public ContactDetails(Contact contact)
        {
            Contact = contact;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Label_Name.Text = Contact.Name;
            Label_Number.Text = Contact.Number;
            Image_Avatar.Source= Contact.PathToPhoto;
        }

        protected void OnClickedTelephoneLabel(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open(Label_Number.Text);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        protected async void OnClickedSMSLabel(object sender, EventArgs e)
        {
            try
            {
                var message = new SmsMessage("", new[] { Label_Number.Text }) ;
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        protected async void OnClickedEditButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactEdit(Contact));
        }

        protected async void OnClickedDeleteButton(object sender, EventArgs e)
        {
            await App.Database.DeleteContact(Contact);
            await Navigation.PopAsync();
        }
    }
}