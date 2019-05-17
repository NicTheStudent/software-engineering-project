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

        public void LogIn(User u)
        {
            currentUser = u;
            loggedIn = true;
        }

        public void LogOut()
        {
            currentUser = null;
            loggedIn = false;
        }

        public User GetUser()
        {
            return currentUser;
        }
    }
}
