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
        Offer offer;
		public ShowMyOffer (Offer offer)
		{
            this.offer = offer;
            RefreshData();

			InitializeComponent ();
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
            List<Order> ordersOnOffer = DatabaseFacade.Instance.GetOrders(offer);
            MainListView.ItemsSource = ordersOnOffer;

        }
    }
}