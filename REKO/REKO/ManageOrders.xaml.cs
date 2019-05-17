using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using REKO.classes;



namespace REKO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageOrders : ContentPage
    {
        public ManageOrders()
        {
            InitializeComponent();
            List<Order> o = new List<Order>();
            o.Add(new Order(1, "Maria", 5, 42));
            listView.ItemsSource = o;
            
        }


    }
}