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
    public partial class ManageOrders : ContentPage
    {
        public ManageOrders()
        {
            InitializeComponent();
            List<Order> o = new List<Order>();
            User user = new User("Maria", "123456");
            Offer offer = new Offer("Grym Getost", "Getost", 42, new Producer("Maria", " ", user, new RekoRing("GBG")), 100, 10, "st", "info", true);
            o.Add(new Order(user, offer, 1, 100));
            listView.ItemsSource = o;
        }

    }
}