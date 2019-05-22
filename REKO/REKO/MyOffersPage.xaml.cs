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
    public partial class MyOffersPage : ContentPage
    {
        public MyOffersPage()
        {
            InitializeComponent();

            RefreshData();
        }

        private async void NewOfferButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewOffer());
        }

        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Offer;
            ShowMyOffer page = new ShowMyOffer(Selected);
            await Navigation.PushAsync(page);
            ((ListView)sender).SelectedItem = null;
        }

        private void RefreshData()
        {
            if(!Session.Instance.IsLoggedIn()) return;

            Producer me = Session.Instance.GetProducer();
            List<Offer> myOffers = DatabaseFacade.Instance.GetOffers(me);
            MainListView.ItemsSource = myOffers;

        }
    }
}