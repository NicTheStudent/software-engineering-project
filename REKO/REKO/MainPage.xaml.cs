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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MainListView.ItemsSource = new List<OfferButton>

            {
            new OfferButton
                {
                Name = "Eggberts Ägg",
                    Description = "12 för 40",
                    Amount = 10,
                    OrderNumber = 1
               },
               new OfferButton
               {
                   Name = "Bertils Betor",
                   Description = "10 kr/kg",
                   Amount = 20,
                   OrderNumber = 2
                },
                new OfferButton
                {
                    Name = "Mjölmers Mjöl",
                    Description = "15 kr/kg",
                    Amount = 35,
                    OrderNumber = 3
               },
               new OfferButton
               {
                   Name = "Niclas Nicotin",
                   Description = "5 för 5",
                   Amount = 400,
                   OrderNumber = 4
                   
               },
               new OfferButton
               {
                   Name = "Niclas Nicotin",
                   Description = "5 för 5",
                   Amount = 400,
                   OrderNumber = 4

               },
               new OfferButton
               {
                   Name = "Niclas Nicotin",
                   Description = "5 för 5",
                   Amount = 400,
                   OrderNumber = 4

               },
               new OfferButton
               {
                   Name = "Niclas Nicotin",
                   Description = "5 för 5",
                   Amount = 400,
                   OrderNumber = 4

               },
               new OfferButton
               {
                   Name = "Niclas Nicotin",
                   Description = "5 för 5",
                   Amount = 400,
                   OrderNumber = 4

               },
               new OfferButton
               {
                   Name = "Niclas Nicotin",
                   Description = "5 för 5",
                   Amount = 400,
                   OrderNumber = 4

               },
               new OfferButton
               {
                   Name = "Niclas Nicotin",
                   Description = "5 för 5",
                   Amount = 400,
                   OrderNumber = 4

               }
           };
        }
        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as OfferButton;

            switch (Selected.OrderNumber)
            {
                case 1:
                    await Navigation.PushAsync(new Page1());
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

               ((ListView)sender).SelectedItem = null;


        }
    }
}