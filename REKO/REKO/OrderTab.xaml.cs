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

        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selected = e.Item as Order;
            DetailedOrder detailedOrder = new DetailedOrder(selected);
            await Navigation.PushAsync(detailedOrder);
            ((ListView)sender).SelectedItem = null;
        }

        public void Handle_Clicked_Remove_My_Order(object sender, EventArgs e)
        {
            var button = sender as Button;
            var order = button.BindingContext as Order;
            DatabaseFacade db = DatabaseFacade.Instance;
            db.RemoveOrder(order);
            //db = DatabaseFacade.Instance;
            MainListView.ItemsSource = db.GetOrders();
            return;
        }
    }
}
