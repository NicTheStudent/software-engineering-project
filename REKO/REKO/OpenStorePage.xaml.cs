using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace REKO
{
    public partial class OpenStorePage : ContentPage
    {
        public OpenStorePage()
        {
            InitializeComponent();
        }

        void Handle_Clicked_Open_Store(object sender, System.EventArgs e)
        {
            if (Session.Instance.IsLoggedIn() == true)
            {
                if (!DatabaseFacade.Instance.GetProducers(Session.Instance.GetUser()).Any()){

                

                var storeName = storeNameEntry.Text;
                var storeDescription = storeDescriptionEntry.Text;
                if (Session.Instance.GetRekoRing() != null)
                    {
                        Producer newProducer = new Producer(storeName, storeDescription, Session.Instance.GetUser(), Session.Instance.GetRekoRing());
                        DatabaseFacade.Instance.AddProducer(newProducer);
                        DisplayAlert("Butik skapad", "du kan nu skapa erbjudanden", "OK");
                        Navigation.PopAsync();
                    }
                else
                    DisplayAlert("Du måste välja RekoRing först", "backa och välj", "OK");
                }
                else
                    DisplayAlert("Du har redan en butik", "Endast en per person", "OK");
            }
            else
                DisplayAlert("Du är inte inloggad", "Vänligen logga in för att kunna skapa ett erbjudande", "OK");
        }
    }
}
