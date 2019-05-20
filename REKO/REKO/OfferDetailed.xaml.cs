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
	public partial class OfferDetailed : ContentPage
	{
        public Offer Offer { get; set; }

        public OfferDetailed (Offer offer)
		{
			InitializeComponent ();
            Offer = offer;
            BindingContext = this;
		}


        public void Handle_Clicked_Place_My_Order(object sender, EventArgs e)
        {

            if (NrOfItems.Text == null)
            {
                DisplayAlert("Felaktig beställning", "Kontrollera att du fyllt i alla fält korrekt", "OK");
            }
            else
            {

               var amount = int.Parse(NrOfItems.Text);

                DatabaseFacade db = DatabaseFacade.Instance;
                var orderNumber = nextOrderNumber(db.GetOrders());  //Checks the hidghest orderNr in the database and gives the next 
                Order newOrder = new Order(Session.Instance.GetUser(), Offer, orderNumber, amount);

                DisplayAlert("Din beställning har lagts!", "Tack för din beställning av " + amount + " " + Offer.Product +
                             "\nDitt ordernummer är: " + orderNumber, "OK");

                db.AddOrder(newOrder);
            }
        }
        /*
         * Looks through all the orders in the DB and returns the highest+1
         */
        private int nextOrderNumber(List<Order> list)
        {
            int tempNr = 0;
            foreach(Order item in list)
            {
                if (item.orderNumber > tempNr)
                    tempNr = item.orderNumber;
            }
            return tempNr + 1;
        }
	}
}