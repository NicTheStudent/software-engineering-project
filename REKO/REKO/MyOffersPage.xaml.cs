using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace REKO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyOffersPage : ContentPage
    {
        public MyOffersPage()
        {
            InitializeComponent();
        }

        private async void NewOfferButton_Clicked(object sender, EventArgs e)
        {
            //RekoRing nyreko = new RekoRing("Stockholm", new DateTime(2019, 7, 16, 18, 0, 0));
            RekoRing nyreko2 = new RekoRing("Stockholm");
            DatabaseFacade.Instance.AddRekoRingWithDate(nyreko2);
            await Navigation.PushAsync(new NewOffer());
        }
    }
}