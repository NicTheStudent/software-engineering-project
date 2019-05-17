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

            List<String> ringList = new List<string>();

            ringList.Add("Göteborg");
            ringList.Add("Borås");
            ringList.Add("Partille");
            ringList.Add("Stenungsund");
            ringList.Add("Kungälv");
            ringList.Add("Mölndal");
            ringList.Add("Hästveda");


            picker.ItemsSource = ringList;
            picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
            ringLabel.Text = "Ingen REKO-ring vald";

            void OnPickerSelectedIndexChanged(object sender, EventArgs e)
            {
                picker = (Picker)sender;
                int selectedIndex = picker.SelectedIndex;

                if (selectedIndex != -1)
                {
                    ringLabel.Text = "Vald: " + (string)picker.ItemsSource[selectedIndex];
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

        void testCell_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Session.Instance.GetUser().username);

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