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
        String name, seller, unit, product;
        double price;
        int available, ordered;
        bool published;

        public Offer(String name, String product, double price, String seller, int available, int ordered, String unit, bool published)
        {
            this.name = name;
            this.product = product;
            this.price = price;
            this.seller = seller;
            this.available = available;
            this.ordered = ordered;
            this.unit = unit;
            this.published = published;
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
        public String GetPriceString()
        {
            return String.Format("{0:F2}", price);
        }
        public String Seller
        {
            get { return seller; }
            set { seller = value; }
        }
        public int Available
        {
            get { return available; }
            set { available = value; }
        }
        public int Ordered
        {
            get { return ordered; }
            set { ordered = value; }
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