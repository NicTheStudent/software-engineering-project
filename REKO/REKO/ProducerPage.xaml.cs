using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace REKO
{
    /* Shows all the details about a specific producer, which is chosen from the list in the ProducerTab
     */
    public partial class ProducerPage : ContentPage
    {

        Producer Producer;
        
        public ProducerPage(Producer producer)
        {     
         InitializeComponent();
         Producer = producer;
         BindingContext = Producer;
         MainListView.ItemsSource = DatabaseFacade.Instance.GetOffers(Producer);
        }

        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Offer;
            OfferDetailed detailedPage = new OfferDetailed(Selected);
            await Navigation.PushAsync(detailedPage);
            ((ListView)sender).SelectedItem = null;
        }
    }
}
