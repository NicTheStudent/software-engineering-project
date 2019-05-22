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
        public String ImagePath { get; set; }
        public String ShortDescription { get; set; }
        public ObjectId id { get; set; }
        public User user { get; set; }
        RekoRing rekoRing;

        public Producer(String name, String description, User user, RekoRing rekoRing, String shortDescription, String imagePath)
        {
            this.user = user;
            this.name = name;
            this.description = description;
            this.rekoRing = rekoRing;
            this.ShortDescription = shortDescription;
            this.ImagePath = imagePath;
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
