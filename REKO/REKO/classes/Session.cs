using System;
using System.Collections.Generic;
using System.Text;

namespace REKO
{
    public sealed class Session
    {
        Boolean loggedIn = false;
        User currentUser;
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

        /*
        public Boolean LogIn(string emailAdress, string password)
        {
            //check database for user with these credentials
        }
        */
        public void LogOut()
        {
            currentUser = null;
            loggedIn = false;
        }

        public User GetUser()
        {
            return currentUser;
        }

        public Boolean IsLoggedIn()
        {
            if (currentUser != null && loggedIn == true)
                return true;
            else return false;
        }
    }
}
