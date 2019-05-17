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

        //This User is a dummy-user, made to test the class.
        User testUser;
        public OfferDetailed (Offer offer)
		{
			InitializeComponent ();
            Offer = offer;
            BindingContext = this;

            testUser = new User("Sam the ham(maker)", "nalle123");
            

		}


        public void Handle_Clicked_Place_My_Order(object sender, EventArgs e)
        {
            var amount = int.Parse(NrOfItems.Text);
            var orderNumber = 3;
            Order newOrder = new Order(testUser, Offer, orderNumber,amount);

            DisplayAlert("Din beställning har lagts!", "Tack för din beställning av " + amount + " " + Offer.Product + 
                         "\n Ditt ordernummer är: " + orderNumber, "OK" );

            //Remove when singleton is implemented
            DatabaseFacade db = DatabaseFacade.Instance;
            db.AddOrder(newOrder);
        }

	}
}