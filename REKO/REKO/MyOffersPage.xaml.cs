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
            await Navigation.PushAsync(new NewOffer());
        }
    }
}