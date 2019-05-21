using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MongoDB.Driver;
using Xamarin.Forms;

namespace REKO
{
    public partial class OrderTab : ContentPage
    {
        public double TotalSumOrders { get; set; }

        public OrderTab()
        {
            InitializeComponent();
            RefreshData();
        }
       
        protected override void OnAppearing() // override this to add refresh on changing to tab
        {
            base.OnAppearing();
            RefreshData();
        }

        private void RefreshData()
        {
            TotalSumOrders = 0;
            MainListView.ItemsSource = null;
            List<Order> userOrders = DatabaseFacade.Instance.GetOrders(Session.Instance.GetUser());
            userOrders.ForEach(Order => TotalSumOrders += Order.Amount * Order.Offer.Price);
            MainListView.ItemsSource = userOrders;
            System.Diagnostics.Debug.WriteLine("DOES IT WORK?  " + TotalSumOrders);
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
