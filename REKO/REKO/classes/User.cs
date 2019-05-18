using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using Xamarin.Forms;

namespace REKO
{
    public class User
    {
        public ObjectId id { get; set; }

        public string username { get; set; }
        public string password { get; set; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;


        }
    }
}

