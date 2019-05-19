using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    public class RekoRing
    {
        public ObjectId id { get; set; }
        public string name { get; set; }

        public RekoRing(string name)
        {
            this.name = name;
        }
    }
}
