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
    public partial class ProducerTab : ContentPage
    {
        public ProducerTab()
        {
            InitializeComponent();

            ProducerListView.ItemsSource = new List<Producer>()
            {
        new Producer {
               Name =  "Eggberts Ägg",
               Description =  " ggg",
               Id = 1337,
               RekoRing = "Gävle"
        }
            };
        }

        async private void ProducerListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Producer;

            switch (Selected.Id)
            {
                case 1337:
                    await Navigation.PushAsync(new Page1());
                    break;
            }

               ((ListView)sender).SelectedItem = null;


        }
    }
}