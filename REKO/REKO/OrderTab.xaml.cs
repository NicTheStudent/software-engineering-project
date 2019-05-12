using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace REKO
{
    public partial class OrderTab : ContentPage
    {
        public OrderTab()
        {
            InitializeComponent();
            DatabaseFacade d = new DatabaseFacade();


            MainListView.ItemsSource = d.offerList;


        }
        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Offer;
            OfferDetailed detailedPage = new OfferDetailed(Selected);
            await Navigation.PushAsync(detailedPage);
        }
    }
}
