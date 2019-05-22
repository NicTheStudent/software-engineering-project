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
                var storeShortDescription = storeShortDescriptionEntry.Text;

                    if (Session.Instance.GetRekoRing() != null)
                    {
                        Producer newProducer = new Producer(storeName, storeDescription, Session.Instance.GetUser(), Session.Instance.GetRekoRing(), storeShortDescription, "Other.png");
                        DatabaseFacade.Instance.AddProducer(newProducer);
                        Session.Instance.UpdateProducer();
                        DisplayAlert("Butik skapad", "du kan nu skapa erbjudanden", "OK");
                        Navigation.PopAsync();
                    }
                    else
                        ChooseRekoRingInAlert();
                }
                else
                    DisplayAlert("Du har redan en butik", "Endast en per person", "OK");
            }
            else
                RedirectOnInfo();
        }

        private async void ChooseRekoRingInAlert()
        {
            DatabaseFacade db = DatabaseFacade.Instance;
            List<RekoRing> rekoRingList = db.GetRekoRings();
            string[] rekoRing = new string[rekoRingList.Count];


            for (int n = 0; n < rekoRing.Length; n++)
            {
                rekoRing[n] = rekoRingList.ElementAt(n).name;
            }

            string result = await DisplayActionSheet("Välj RekoRing", "Avbryt", null, rekoRing);
            
            foreach (RekoRing item in rekoRingList)
                if (item.name.Equals(result))
                {
                    Session.Instance.SetRekoRing(item);
                }
        }

        public async void RedirectOnInfo()
        {
            bool answer = await DisplayAlert("Inloggning krävs", "För att öppna en butik måste du vara inloggad", "Logga in","Avbryt");
            if (answer)
            { await Navigation.PushAsync(new LoginPage()); }
        }
        
    }
}
