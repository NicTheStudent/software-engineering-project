using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    public class User
    {
        public ObjectId id { get; set; }
        public string emailAdress { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int phoneNumber { get; set; }

    }

    /*
    public class Producer
    {
        public ObjectId id { get; set; }
        public User user { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }

    }
    */ 

    public class RekoRing
    {
        public ObjectId id { get; set; }
        public string name { get; set; }
    }

    public class Offer // denna klass måste ses över, t.ex måste få ObjectId id
    {

        String name, seller, unit;
        double price;
        int available, ordered;
        bool published;

        public Offer(String name, double price, String seller, int available, int ordered, String unit, bool published)
        {
            this.name = name;
            this.price = price;
            this.seller = seller;
            this.available = available;
            this.ordered = ordered;
            this.unit = unit;
            this.published = published;
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
