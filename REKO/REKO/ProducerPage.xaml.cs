using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace REKO
{
    /* Shows all the details about a specific producer, which is chosen from the list in the ProducerTab
     */
    public partial class ProducerPage : ContentPage
    {

        Producer Producer { get; set; }
        public ProducerPage(Producer producer)
        {
            
         InitializeComponent();

            Producer = producer;
            BindingContext = this;
        }

        

    }
}
