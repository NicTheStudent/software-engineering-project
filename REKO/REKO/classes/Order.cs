using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    class Order
    {
        public int orderAmount;
        public ObjectId offer;
        public ObjectId buyer;

        public Order(Offer o, User u, int amount)
        {
            orderAmount = amount;
            offer = o.Id;
            buyer = u.Id;
        }
    }


}
