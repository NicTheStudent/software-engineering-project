﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Android;
using Xamarin.Forms;

namespace REKO
{
    public partial class OfferTab : ContentPage
    {

        public OfferTab()
        {
            InitializeComponent();
            DatabaseFacade db = DatabaseFacade.Instance;
            MainListView.ItemsSource = db.GetOffers();

            UpdateRingInfo();

        }

        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Offer;
            OfferDetailed detailedPage = new OfferDetailed(Selected);
            await Navigation.PushAsync(detailedPage);
            ((ListView)sender).SelectedItem = null;
        }

        public void UpdateRingInfo()
        {
            RekoRing current = Session.Instance.GetRekoRing();
            if (current == null)
            {
                rekoringname.Text = "Ingen REKO-ring vald.";
                rekoringmeetup.Text = "";
            }
            else
            {
                rekoringname.Text = "REKO-ring: " + current.name;
                rekoringmeetup.Text = "Nästa meetup: " + current.nextMeetup.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));
            }
        }

    }
}