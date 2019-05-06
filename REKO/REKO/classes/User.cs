using System;

using Xamarin.Forms;

namespace REKO.classes
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;

        }

        public bool LoginValidation()
        {
            if (!this.Username.Equals(" ") && !this.Password.Equals(" "))
                return true;
            else
                return false;
        }

    }
}

