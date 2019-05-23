using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace REKO
{
    public partial class AccountTab : ContentPage
    {


        public AccountTab()
        {
            InitializeComponent();

            List<RekoRing> ringList = DatabaseFacade.Instance.GetRekoRings();

            List<string> stringRingList = new List<string>();
            ringList.ForEach(RekoRing => stringRingList.Add(RekoRing.name)); // inte 100% snyggt men funkar

            picker.ItemsSource = stringRingList;

            picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
            ringLabel.Text = "Ingen REKO-ring vald";           


            void OnPickerSelectedIndexChanged(object sender, EventArgs e)
            {
                picker = (Picker)sender;
                int selectedIndex = picker.SelectedIndex;

                if (selectedIndex != -1)
                {
                    ringLabel.Text = "Vald: " + (string)picker.ItemsSource[selectedIndex];
                    Session.Instance.SetRekoRing(ringList[picker.SelectedIndex]);
                }
                else
                {
                    ringLabel.Text = "Ingen REKO-ring vald";
                }
            }

        }

        protected override void OnAppearing() // override this to add refresh on changing to tab
        {
            base.OnAppearing();
            HideOrShowOptions();
        }


        TableSection loginSignup;
        TableSection openStore;
        TableSection myOffers;
        TableSection logout;

        private void HideOrShowOptions()
        {
            if (loginSignup != null)
                loginSignup = Table.Root[Table.Root.IndexOf(loginSection)];
            if (openStore != null)
                openStore = Table.Root[Table.Root.IndexOf(openStoreSection)];
            if (myOffers != null)
                myOffers = Table.Root[Table.Root.IndexOf(myOffersSection)];
            if (logout != null)
                logout = Table.Root[Table.Root.IndexOf(logoutSection)];

            Table.Root.Remove(loginSection);
            Table.Root.Remove(openStoreSection);
            Table.Root.Remove(myOffersSection);
            Table.Root.Remove(logoutSection);

            if (!Session.Instance.IsLoggedIn())
                Table.Root.Insert(0, loginSection);
            else
                Table.Root.Insert(0, logoutSection);

            if (Session.Instance.HasStore())
                Table.Root.Insert(0, myOffersSection);

            else if (Session.Instance.IsLoggedIn())
                Table.Root.Insert(0, openStoreSection);
        }



        async void MyOffersCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyOffersPage());
        }

        async void OlderOrdersCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OldOrders());
        }

        async void loginCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        async void signUpCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void openStoreCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OpenStorePage());
        }

        void populateCell_Tapped(object sender, EventArgs e)
        {
            var popdb = new PopulateDB();
            popdb.Populate(); ;
        }

        void logoutCell_Tapped(object sender, EventArgs e)
        {
            Session.Instance.LogOut();
            HideOrShowOptions();
            DisplayAlert("Du har loggats ut", "Vi saknar dig redan", "OK");

        }

        void testCell_Tapped(object sender, EventArgs e)
        {
            //for testing
        }

        /*
        async void AboutAppCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutAppPage());
        }
        */

    }
}