using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace REKO
{
    public partial class NewOffer : ContentPage
    {
        public NewOffer()
        {
            InitializeComponent();
        }

        void Handle_Clicked_Create_Offer(object sender, System.EventArgs e)
        {
            if (Session.Instance.IsLoggedIn() && Session.Instance.HasStore())
            {
                var name = offerNameEntry.Text;
                var product = productEntry.Text;
                var price = Double.Parse(priceEntry.Text);
                var unit = unitEntry.Text;
                var availableAmount = int.Parse(amountEntry.Text);
                var orderedAmount = 0;

                Offer newOffer = new Offer(name, product, price, Session.Instance.GetProducer(), availableAmount, orderedAmount, unit, true);
                DatabaseFacade db = DatabaseFacade.Instance;
                db.AddOffer(newOffer);
                DisplayAlert("Nytt erbjudande skapat", "Det blir säkerligen mycket populärt", "OK");
                Navigation.PopAsync();
            }
            else if (!Session.Instance.IsLoggedIn())
            {
                RedirectNotLoggedIn();
            }
            else if (!Session.Instance.HasStore())
            {
                RedirectNoStore();
            }
        }

        private async void RedirectNotLoggedIn()
        {
        var result = await DisplayAlert("Du är inte inloggad", "Vänligen logga in för att kunna skapa ett erbjudande", "Logga in", "Avbryt");
            if (result)
            {
               await Navigation.PushAsync(new LoginPage());
            }
        }

        private async void RedirectNoStore()
        {
            var result = await DisplayAlert("Du har ingen butik", "Vänligen öppna en butik för att kunna erbjuda kunder dina produkter", "Öppna butik", "Avbryt");
            if (result)
            {
              await  Navigation.PushAsync(new OpenStorePage());
            }
        }
    }
}
