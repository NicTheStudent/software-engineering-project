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
	public partial class ShowMyOffer : ContentPage
	{
        public Offer Offer { get; set; }
        public ShowMyOffer (Offer offer)
		{
            InitializeComponent();
            this.Offer = offer;
            RefreshData();
            BindingContext = this;
    }


        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Offer;
            OfferDetailed detailedPage = new OfferDetailed(Selected);
            await Navigation.PushAsync(detailedPage);
            ((ListView)sender).SelectedItem = null;
        }

        private void RefreshData()
        {
            if (Offer != null)
            {
                List<Order> ordersOnOffer = DatabaseFacade.Instance.GetOrders(Offer);
                MainListView.ItemsSource = ordersOnOffer;
            }
            else
            {
                MainListView.ItemsSource = null;
            }
            

        }

        async private void Handle_Clicked_Remove_My_Offer(object sender, EventArgs e)
        {

            bool answer = await DisplayAlert("Ta bort erbjudande?", "Är du säker på att du vill ta bort ditt erbjudande?", "Ja", "Nej");
            if (!answer) return;

            List<Order> ordersOnOffer = DatabaseFacade.Instance.GetOrders(Offer);
            ordersOnOffer.ForEach(Order => DatabaseFacade.Instance.RemoveOrder(Order));
            DatabaseFacade.Instance.RemoveOffer(Offer);
            Offer = null;
            RefreshData();
            await Navigation.PopAsync();
            //await Navigation.PushAsync(new MyOffersPage());
            return;
        }
    }
}