using REKO.classes;
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

        public OfferTab()
        {
            InitializeComponent();
            DatabaseFacade d = new DatabaseFacade();
            

            MainListView.ItemsSource = d.OfferList;


        }
        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Offer;
            OfferDetailed detailedPage = new OfferDetailed(Selected);
            await Navigation.PushAsync(detailedPage);
            /*
            switch (Selected.OfferId)
            {
                case 1:
                    await Navigation.PushAsync(detailedPage);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

               ((ListView)sender).SelectedItem = null;
               */

        }
    }
}