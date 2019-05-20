using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


//TODO Fixa med table view.
//TODO Kolla så all info är med.
namespace REKO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailedOrder : ContentPage
    { 
        public Order Order {get; set;}
       
 public DetailedOrder(Order order)
        {
            InitializeComponent();
            Order = order;
            BindingContext = this;
        }
    }
}
