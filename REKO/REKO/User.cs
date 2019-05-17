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
}
