using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace REKO
{
    public partial class OldOrders : ContentPage
    {
        List<Order> oldOrderList;

        public OldOrders()
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

            oldOrderList = DatabaseFacade.Instance.GetOrdersFilteredOldAndUser(Session.Instance.GetUser());
            MainListView.ItemsSource = null;
            MainListView.ItemsSource = oldOrderList;
        }

        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selected = e.Item as Order;
            DetailedOrder detailedOrder = new DetailedOrder(selected);
            await Navigation.PushAsync(detailedOrder);
            ((ListView)sender).SelectedItem = null;
        }
    }
}
