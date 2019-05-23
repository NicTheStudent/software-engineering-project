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
            List<Order> ordersOnOffer = DatabaseFacade.Instance.GetOrders(Offer);
            MainListView.ItemsSource = ordersOnOffer;

        }
    }
}