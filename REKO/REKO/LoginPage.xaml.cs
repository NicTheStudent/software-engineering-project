using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace REKO
{
    public partial class LoginPage : ContentPage
    { 
        /*LoginPage which is now set at the first page that comes up when the app is opened. (Set in app.xaml.cs)
         * 
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
