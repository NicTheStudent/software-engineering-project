using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace REKO
{
    // CLASS CURRENTLY NOT IN USE
    public partial class LoginPage : ContentPage
    { 
        /*
         * LoginPage which is now set at the first page that comes up when the app is opened. (Set in app.xaml.cs)
         */

        public LoginPage()
        {
            InitializeComponent();
        }

        /*
         * Dummy-function which handles the loginvalidation. Should probably be rewritten in the future, when the connection to the
         * database is made.        
         */
        void LoginClicked(object sender, EventArgs e)
        {
            if (Ent_Anvnamn.Text != null && Ent_Lösen.Text != null)
            {
                if (Session.Instance.LogIn(Ent_Anvnamn.Text, Ent_Lösen.Text) == true)
                {
                    DisplayAlert("Inloggning lyckades", "Inloggad som " + Session.Instance.GetUser().username, "OK");
                    Navigation.PopAsync();
                }
                else
                    DisplayAlert("Inloggning misslyckades", "Användarnamn och/eller lösenord inkorrekt", "OK");
            }
            else
                DisplayAlert("Fyll i både användarnamn och lösenord", "Någon av rutorna är tom", "OK");


            /*
            User user = new User(Ent_Anvnamn.Text, Ent_Lösen.Text);

            if (user.LoginValidation())
            {
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Inloggning", "Inloggning misslyckades",  "Försök igen");
            } */
        }
    }
}
