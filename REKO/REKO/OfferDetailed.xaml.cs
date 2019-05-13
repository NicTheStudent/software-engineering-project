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
	public partial class OfferDetailed : ContentPage
	{
        public Offer Offer { get; set; }
		public OfferDetailed (Offer offer)
		{
			InitializeComponent ();
            Offer = offer;
            BindingContext = this;
		}

	}
}