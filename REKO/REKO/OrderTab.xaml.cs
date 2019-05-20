using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MongoDB.Driver;
using Xamarin.Forms;

namespace REKO
{
    public partial class OrderTab : ContentPage
    {

        public OrderTab()
        {
            InitializeComponent();
            DatabaseFacade db = DatabaseFacade.Instance;
            MainListView.ItemsSource = db.GetOrders();

        }

        protected override void OnAppearing() // override this to add refresh on changing to tab
        {
            base.OnAppearing();
            RefreshData();
        }

        private void RefreshData()
        {
            MainListView.ItemsSource = null;
            MainListView.ItemsSource = DatabaseFacade.Instance.GetOffers();
        }

        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selected = e.Item as Order;
            DetailedOrder detailedOrder = new DetailedOrder(selected);
            await Navigation.PushAsync(detailedOrder);
            ((ListView)sender).SelectedItem = null;
        }

        async private void Handle_Clicked_Remove_My_Order(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Avbeställa?", "Är du säker på att du vill avbeställa?", "Ja", "Nej");
            if (!answer) return;

            var button = sender as Button;
            var order = button.BindingContext as Order;
            DatabaseFacade db = DatabaseFacade.Instance;
            db.RemoveOrder(order);
            MainListView.ItemsSource = db.GetOrders();
            return;
        }
    }
}
