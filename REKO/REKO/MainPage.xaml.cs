using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Android;
using Xamarin.Forms;

namespace REKO
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {

        int amount = 0;
        String[] prod_sing = {"lök", "ägg", "mjöl"};
        String[] prod_plur = { "lökar", "ägg", "mjöl"};
        int prodIndex = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            int round = (int)(e.NewValue);
            this.BackgroundColor = Color.FromRgb(255, 255-round, 255);
        }

        void Increase(object sender, System.EventArgs e)
        {
            amount++;
            if(amount == 1)
            {
                label1.Text = String.Format("Jag vill beställa {0} {1}!", amount, prod_sing[prodIndex]);
            }
            else
            {
                label1.Text = String.Format("Jag vill beställa {0} {1}!", amount, prod_plur[prodIndex]);
            }

        }
        void Decrease(object sender, System.EventArgs e)
        {
            amount--;
            if (amount < 0) amount = 0;
            if (amount == 1)
            {
                label1.Text = String.Format("Jag vill beställa {0} {1}!", amount, prod_sing[prodIndex]);
            }
            else
            {
                label1.Text = String.Format("Jag vill beställa {0} {1}!", amount, prod_plur[prodIndex]);
            }
        }
        void Change_Product(object sender, System.EventArgs e)
        {
            prodIndex++;
            if (prodIndex >= prod_sing.Length) prodIndex = 0;
            if (amount == 1)
            {
                label1.Text = String.Format("Jag vill beställa {0} {1}!", amount, prod_sing[prodIndex]);
            }
            else
            {
                label1.Text = String.Format("Jag vill beställa {0} {1}!", amount, prod_plur[prodIndex]);
            }
        }
    }
}














