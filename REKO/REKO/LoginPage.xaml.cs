using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace REKO
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void LoginClicked(object sender, EventArgs e)
        {
            classes.User user = new classes.User(Ent_Anvnamn.Text, Ent_Lösen.Text);

            if (user.LoginValidation())
            {
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Inloggning", "Inloggning misslyckades",  "Försök igen");
            }
        }
    }
}
