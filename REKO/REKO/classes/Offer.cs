﻿using System;
namespace REKO
{
    public class Offer
    {

        String name, seller, unit;
        double price;
        int available, ordered, offerId;
        bool published;

        public Offer(String name, double price, String seller, int available, int ordered, String unit, bool published, int offerId)
        {
            this.name = name;
            this.price = price;
            this.seller = seller;
            this.available = available;
            this.ordered = ordered;
            this.unit = unit;
            this.published = published;
            this.offerId = offerId;
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
        public int OfferId
        {
            get { return offerId; }
            set { offerId = value; }
        }

        //----------------------------------



    }
}