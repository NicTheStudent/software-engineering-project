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
        async void MyOffersCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyOffersPage());
        }

        async void loginCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        async void signUpCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        void testCell_Tapped(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(Session.Instance.GetUser().username);
            System.Diagnostics.Debug.WriteLine(Session.Instance.GetRekoRing().name);
            /*
            var db = DatabaseFacade.Instance;
            db.GetUsers().ForEach(User => System.Diagnostics.Debug.WriteLine(User.firstName)); // 
            */
        }

        /*
        async void AboutAppCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutAppPage());
        }
        */
    }
}