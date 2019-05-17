using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace REKO
{
    public partial class NewOffer : ContentPage
    {
        public NewOffer()
        {
            InitializeComponent();
        }

        void Handle_Clicked_Create_Offer(object sender, System.EventArgs e)
        {
            if (Session.Instance.IsLoggedIn() == true)
            {
            var name = offerNameEntry.Text;
            var product = productEntry.Text;
            var price = Double.Parse(priceEntry.Text);
            var unit = unitEntry.Text;
            var amount = int.Parse(amountEntry.Text);
            var username = Session.Instance.GetUser().username;

            Offer newOffer = new Offer(name, product, price, username, amount, 0, unit, true);
            DatabaseFacade db = DatabaseFacade.Instance;
            db.AddOffer(newOffer);

            newOfferLabel.Text = "Nytt erbjudande skapat.";
            }
            else
                DisplayAlert("Du är inte inloggad", "Vänligen logga in för att kunna skapa ett erbjudande", "OK");
        }

        }
    }
}
