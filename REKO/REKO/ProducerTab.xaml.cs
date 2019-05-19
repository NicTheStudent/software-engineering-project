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

            List<RekoRing> ringList = new List<RekoRing>();
            ringList.Add(new RekoRing("Göteborg"));
            ringList.Add(new RekoRing("Borås"));
            ringList.Add(new RekoRing("Partille"));
            ringList.Add(new RekoRing("Stenungsund"));
            ringList.Add(new RekoRing("Mölndal"));
            ringList.Add(new RekoRing("Hästveda"));

            List<User> userList = new List<User>();
            userList.Add(new User("Namorb", "pw"));
            userList.Add(new User("Fripperian", "pw"));
            userList.Add(new User("NictheStudent", "pw"));
            userList.Add(new User("FornMaria", "pw"));
            userList.Add(new User("oscgro19", "pw"));
            userList.Add(new User("ssamuelandersson", "pw"));
            userList.Add(new User("LucasAndren", "pw"));

            List<Producer> producerList = new List<Producer>();
            producerList.Add(new Producer("Eggberts Äggfarm", "Jag har 800 hönor men är allergisk mot ägg, säljer därför av lite nu till påsk", userList[0], ringList[0]));
            producerList.Add(new Producer("Bertils Betodling", "Säljer schyssta röd-, gul- och polkabetor", userList[1], ringList[0]));
            producerList.Add(new Producer("Grönqvists gurkplantage", "Salta och söta", userList[2], ringList[0]));
            producerList.Add(new Producer("Marias Margarinfabrik", "Perfekt för morgonmackan", userList[3], ringList[0]));


            ProducerListView.ItemsSource = DatabaseFacade.Instance.GetProducers();

        }

async private void ProducerListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as Producer;

            await Navigation.PushAsync(new ProducerPage(Selected));

               ((ListView)sender).SelectedItem = null;


        }
    }
}