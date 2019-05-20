using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    public class Order
    {
        /*
         * This class represents a order. When a order is placed, a new instance of this class is created.
         * When a order is deleted this classes delete method should be called. (TODO)
         * OrderNumber is the same number as the key in Dictonary found in Offer.cs.
         * To create a instance of Order, one must be logged in.
         * A order is created when "Beställ" is pressed.
         * 
         * All vars set to public, to be able to see how eveything works in MongoDB
         */
        public ObjectId id { get; set; }
        public User user { get; set; }
        public Offer offer { get; set; }
        public int orderNumber;
        public int amount;

        public Order(User user, Offer offer, int orderNumber, int amount)
        {
            this.user = user;
            this.offer = offer;
            this.orderNumber = orderNumber;
            this.amount = amount;
        }

        public int OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public double OrderSum()
        {
            return amount * offer.Price;
        }
    }
}
