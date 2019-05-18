using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    public class Producer
    {
        String name, description;
        public ObjectId id { get; set; }
        User user;
        RekoRing rekoRing;

        public Producer(String name, String description, User user, RekoRing rekoRing)
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
        public RekoRing RekoRing
        {
            get { return rekoRing; }
            set { rekoRing = value; }
        }
    }
}
