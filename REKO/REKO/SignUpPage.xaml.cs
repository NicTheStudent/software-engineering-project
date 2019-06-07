using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace REKO
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent();
		}

        void SignUpClicked(object sender, EventArgs e)
        {
            if (Ent_Lösen1.Text != Ent_Lösen2.Text) // check matching passwords
                DisplayAlert("Konto kunde inte skapas", "Lösenorden stämmer inte överens", "OK"); 
            else if (DatabaseFacade.Instance.CheckUsernameExists(Ent_Anvnamn.Text))
                DisplayAlert("Konto kunde inte skapas", "Användarnamnet är upptaget ", "OK");
            else
            {
                User newUser = new User(Ent_Anvnamn.Text, Ent_Lösen1.Text);
                DatabaseFacade.Instance.AddUser(newUser);
                DisplayAlert("Konto skapat", "Välkommen till klubben", "OK");
            }
                
        }
    }
}