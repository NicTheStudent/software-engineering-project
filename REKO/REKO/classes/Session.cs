using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    // Singleton class that logs users in or out and keep tracks of who is logged in..

    public sealed class Session
    {
        Boolean loggedIn = false;
        User currentUser;
        RekoRing currentRekoRing;
        Producer currentProducer;

        private static readonly Session INSTANCE = new Session();

        private Session()
        {
        }

        public static Session Instance
        {
            get
            {
                return INSTANCE;
            }
        }

        
        public Boolean LogIn(string username, string password)
        {
            var dbf = DatabaseFacade.Instance;
            var filter = Builders<User>.Filter.Eq(user => user.username, username) & Builders<User>.Filter.Eq(user => user.password, password);
            List<User> loggedInUser = dbf.GetUsersFiltered(filter);
            if (loggedInUser[0] != null)
            {
                currentUser = loggedInUser[0];
                loggedIn = true;
                List<Producer> checkProducer = DatabaseFacade.Instance.GetProducers(currentUser);
                if (checkProducer.Any()) // check if user has a store
                    UpdateProducer();
                else
                    currentProducer = null;
                return true; //login success
            }
            else
                return false; //login fail
        }
        

        public void UpdateProducer()
        {
            currentProducer = DatabaseFacade.Instance.GetProducers(currentUser)[0];
        }


        public void LogOut()
        {
            currentUser = null;
            currentProducer = null;
            loggedIn = false;
        }

        public User GetUser()
        {
            return currentUser;
        }

        public Boolean IsLoggedIn()
        {
            return (currentUser != null && loggedIn);
        }

        public Boolean HasStore()
        {
            return (currentProducer != null && IsLoggedIn());
        }

        public void SetRekoRing(RekoRing newRing)
        {
            currentRekoRing = newRing;
        }

        public RekoRing GetRekoRing()
        {
            return currentRekoRing;
        }

        public Producer GetProducer()
        {
            return currentProducer;
        }
    }
}
