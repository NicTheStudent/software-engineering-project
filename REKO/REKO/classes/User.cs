using System;

using Xamarin.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    public class User
    {
        public ObjectId id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;

        }
    }
}

