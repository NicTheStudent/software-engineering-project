using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MongoDB.Driver;
using Xamarin.Forms;

namespace REKO
{
    public partial class OrderTab : ContentPage
    {
        private double _orderSum;
        public double TotalOrderSum
        {
            get { return _orderSum; }
            set { _orderSum = value; OnPropertyChanged(); }
        }
        List<Order> orderList;
       
    
        public OrderTab()
        {
            InitializeComponent();
            RefreshData();
            BindingContext = this;
        }
         
        protected override void OnAppearing() // override this to add refresh on changing to tab
        {
            base.OnAppearing();
            RefreshData();
        }

        private void RefreshData()
        {

            orderList = DatabaseFacade.Instance.GetOrders(Session.Instance.GetUser());
            MainListView.ItemsSource = null;
            MainListView.ItemsSource = orderList;
            TotalOrderSum = 0;
            orderList.ForEach(Order => TotalOrderSum += Order.OrderSum);
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
            DatabaseFacade db = DatabaseFacade.Instance;

            bool answer = await DisplayAlert("Avbeställa?", "Är du säker på att du vill avbeställa?", "Ja", "Nej");
            if (!answer) return;
            var button = sender as Button;
            var order = button.BindingContext as Order;

            var filter = Builders<Offer>.Filter.Eq(Offer => Offer.Id, order.Offer.Id);
            List<Offer> changedOffer = db.GetOffersFiltered(filter);

            db.RemoveOrder(order);
            MainListView.ItemsSource = db.GetOrders();

            changedOffer[0].CurrentAmount += order.Amount;
            db.UpdateOfferAmount(changedOffer[0]);
            return;
        }
    }
}
