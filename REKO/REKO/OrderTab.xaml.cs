﻿using System;
using System.Collections.Generic;
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
            var Selected = e.Item as Order;
            DetailedOrder detailedOrder = new DetailedOrder(Selected);
            await Navigation.PushAsync(detailedOrder);
            ((ListView)sender).SelectedItem = null;
        }
    }
}
