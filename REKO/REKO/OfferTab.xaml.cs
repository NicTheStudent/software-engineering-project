using System;
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

        List<Offer> resultsList;

        public OfferTab()
        {
            InitializeComponent();
            UpdateRingInfo();
        }

        protected override void OnAppearing() // override this to add refresh on changing to tab
        {
            base.OnAppearing();
            RefreshData();
        }

        private void RefreshData()
        {
            resultsList = DatabaseFacade.Instance.GetOffers();
            FilterOnSearchString(MainListViewSearchBar.Text);
            UpdateRingInfo();
        }

        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Offer;
            OfferDetailed detailedPage = new OfferDetailed(Selected);
            await Navigation.PushAsync(detailedPage);
            ((ListView)sender).SelectedItem = null;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            FilterOnSearchString(e.NewTextValue);
        }

        private void FilterOnSearchString(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                MainListView.ItemsSource = resultsList;
            }
            else
            {
                var searchedOfferList = new List<Offer>();
                searchedOfferList.AddRange(resultsList.Where(offer => offer.Name.ToUpper().Contains(searchString.ToUpper())));
                searchedOfferList.AddRange(resultsList.Where(offer => offer.Product.ToUpper().Contains(searchString.ToUpper())));
                MainListView.ItemsSource = searchedOfferList;
            }
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
                rekoringmeetup.Text = "Nästa meetup:"+Environment.NewLine + current.nextMeetup.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));

            }
        }
    }
}
