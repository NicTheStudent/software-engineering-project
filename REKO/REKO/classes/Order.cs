using System;
using System.Collections.Generic;
using System.Text;

namespace REKO.classes
{
    public class Order
    {
        int ordNo;
        String name;
        double price;
        int amount;
     

        public Order(int ordNo, String name, int amount, double price)
        {
            this.ordNo = ordNo;
            this.name = name;         
            this.price = price;
            this.amount = amount;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public String GetPriceString()
        {
            return String.Format("{0:F2}", price);
        }
        public int OrdNo
        {
            get { return ordNo; }
            set { ordNo = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        

        //----------------------------------



    }
}
