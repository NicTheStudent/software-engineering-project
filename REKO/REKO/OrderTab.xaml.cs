using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MongoDB.Driver;
using Xamarin.Forms;

namespace REKO
{
    public partial class OrderTab : ContentPage
    {
        double totalOrderSum;
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
            orderList = DatabaseFacade.Instance.GetOrders();
            MainListView.ItemsSource = null;
            MainListView.ItemsSource = orderList;
            CalculateOrderSum();
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

        public double CalculateOrderSum()
        {
            foreach (Order order in orderList)
            {
                totalOrderSum = totalOrderSum + order.OrderSum;
            }
            return totalOrderSum;

        }
        public double TotalOrderSum
        {
            get
            {
                return CalculateOrderSum();
            }
        }

    }
}
