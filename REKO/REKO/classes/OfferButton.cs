using System;
using System.Collections.Generic;
using System.Text;

namespace REKO.classes { 

    public class OfferButton
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Amount { get; set; }
        public int OrderNumber { get; set; }

        //Can't bind several properties on a View Element in MainPage.xaml, this is one way of solving it
        public string DescriptionText = "Mängd av vara: ";
        public string AmountDescription => $"{DescriptionText} {Amount}";
    }

}
