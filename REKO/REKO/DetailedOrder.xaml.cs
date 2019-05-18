using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace REKO
{
    public partial class DetailedOrder : ContentPage
    {

        Order Order {get; set;}
       
 public DetailedOrder(Order order)
        {
            InitializeComponent();
            Order = order;
            BindingContext = this;
        }
    }
}
