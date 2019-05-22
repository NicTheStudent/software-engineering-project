using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    public class Offer
    {
        ObjectId id;
        String name, unit, product;
        Producer seller;
        double price;
        int startAmount, currentAmount, orderedAmount;
        bool published;


        public Offer(String name, String product, double price, Producer seller, int startAmount, int orderedAmount, String unit, bool published)
        {
            this.name = name;
            this.product = product;
            this.price = price;
            this.seller = seller;
            this.startAmount = startAmount; 
            this.orderedAmount = orderedAmount;
            this.unit = unit;
            this.published = published;
            this.currentAmount = startAmount;
        }
        public ObjectId Id
        {
            get { return id;}
            set { id = value; }
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

        public String Product
        {
            get { return product; }
            set { product = value; }
        }
        public String GetPriceString()
        {
            return String.Format("{0:F2}", price);
        }
        public Producer Seller
        {
            get { return seller; }
            set { seller = value; }
        }
        public int StartAmount
        {
            get { return startAmount; }
            set { startAmount = value; }
        }

        public int CurrentAmount
        {
            get { return currentAmount; }
            set { currentAmount = value; }
        }

        public int OrderedAmount
        {
            get { return orderedAmount; }
            set { orderedAmount = value; }
        }
        public String Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        public bool Published
        {
            get { return published; }
            set { published = value; }
        }

        //----------------------------------



    }
}