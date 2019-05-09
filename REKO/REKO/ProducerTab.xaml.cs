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
            DatabaseFacade data = new DatabaseFacade();

            ProducerListView.ItemsSource = data.ProducerList;

    
        }


        async private void ProducerListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Producer;

           

               ((ListView)sender).SelectedItem = null;


        }
    }
}