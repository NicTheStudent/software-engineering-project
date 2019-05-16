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
            var name = offerNameEntry.Text;
            var product = productEntry.Text;
            var price = Double.Parse(priceEntry.Text);
            var unit = unitEntry.Text;
            var amount = int.Parse(amountEntry.Text);

            Offer newOffer = new Offer(name, product, price, "Bertil", amount, 0, unit, true);

            newOfferLabel.Text = "Nytt erbjudande skapat.";

            DatabaseFacade db = new DatabaseFacade();
            db.AddOffer(newOffer);
        }
    }
}
