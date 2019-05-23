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
         */
        public ObjectId id { get; set; }

        private User user;
        private Offer offer;
        private int orderNumber;
        private int amount;
        private DateTime timeSold;
        
        public Order(User user, Offer offer, int orderNumber, int amount, DateTime timeSold)
        {
            this.user = user;
            this.offer = offer;
            this.orderNumber = orderNumber;
            this.amount = amount;
            //Lägger till två timmar för att ordern ska bli gammal efter att ringen är över
            this.timeSold = timeSold.AddHours(2);
        }

        public Offer Offer
        {
            get { return offer; }
            set { offer = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
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

        public DateTime TimeSold
        {
            get { return timeSold; }
            set { timeSold = value; }
        }

        public double OrderSum
        {
            get { return amount * Offer.Price; }
        }


        /*
        public String Name
        {
            get { return user.username; }
            set { Name = value; }
        }


        public String Price
        {
            get { return offer.GetPriceString(); }
            set { Price = value; }
        }
        */

    }
}
