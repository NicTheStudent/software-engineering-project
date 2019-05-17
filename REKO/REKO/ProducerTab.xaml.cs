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

    /* This class represents the tab in which all the producers are shown.
     * All the producers are all visualized in a list.
     * 
     */    
    public partial class ProducerTab : ContentPage
    {
        public ProducerTab()
        {
            InitializeComponent();
            DatabaseFacade data = DatabaseFacade.Instance;

            ProducerListView.ItemsSource = data.ProducerList;

    
        }

async private void ProducerListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Producer;

            await Navigation.PushAsync(new ProducerPage(Selected));

               ((ListView)sender).SelectedItem = null;


        }
    }
}