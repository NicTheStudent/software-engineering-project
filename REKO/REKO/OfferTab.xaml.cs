using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using Android;
using Xamarin.Forms;

namespace REKO
{
    public partial class OfferTab : ContentPage
    {
        private bool _isRefreshing = false;
        public bool IsRefreshing // bound to MainListView
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        protected override void OnAppearing() // override this to add refresh on changing to tab
        {
            base.OnAppearing();
            RefreshData();
        }

        public OfferTab()
        {
            InitializeComponent();
            BindingContext = this;
            DatabaseFacade db = DatabaseFacade.Instance;
            MainListView.ItemsSource = db.GetOffers();
        }

        public ICommand RefreshCommand // bound to MainListView
        {
            get
            {
                return new Command(() =>
                {
                    IsRefreshing = true;
                    RefreshData();
                    IsRefreshing = false;
                });
            }
        }

        private void RefreshData()
        {
            MainListView.ItemsSource = null;
            MainListView.ItemsSource = DatabaseFacade.Instance.GetOffers();
        }

        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Offer;
            OfferDetailed detailedPage = new OfferDetailed(Selected);
            await Navigation.PushAsync(detailedPage);
            ((ListView)sender).SelectedItem = null;
        }
    }
}