using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    public class Producer
    {
        String name, description, rekoRing;
        public ObjectId id { get; set; }
        User user;

        public Producer(String name, String description, RekoRing rekoRing, User user)
        {
            this.user = user;
            this.name = name;
            this.description = description;
            this.rekoRing = rekoRing;
        }
        public string Name
        {
            get { return name;}
            set { name = value;}
        }
        public string Description
        {
            get { return description;}
            set { description = value;}
        }
        public string RekoRing
        {
            get { return rekoRing; }
            set { rekoRing = value; }
        }
    }
}
