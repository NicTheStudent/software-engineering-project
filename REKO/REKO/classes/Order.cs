using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    class Order
    {


        /*
* This class represents a order. When a order is placed, a new instance of this class is created.
* When a order is deleted this classes delete method should be called. (TODO)
* OrderNumber is the same number as the key in Dictonary found in Offer.cs.
* To create a instance of Order, one must be logged in.
* A order is created when "Beställ" is pressed.
*/

        private ObjectId id { get; set; }
        private User user { get; }
        private Offer offer { get; }
        private int orderNumber { get; }
        private int amount { get; }


        public Order(User user, Offer offer, int orderNumber, int amount)
        {
            this.user = user;
            this.offer = offer;
            this.orderNumber = orderNumber;
            this.amount = amount;
        }

        public String Name
        {
            get { return user.Username; }
            set { Name = value; }
        }

        public String Price
        {
            get { return offer.GetPriceString(); }
            set { Price = value; }
        }
    }
}