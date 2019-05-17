using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    public class PopulateDB
    {
        public PopulateDB()
        {
        }


        public void Populate()
        {
            PopulateRings();
            PopulateUsers();
        }

        private void PopulateRings()
        {
            List<RekoRing> checkList = DatabaseFacade.Instance.GetRekoRings();

            if (!checkList.Any())
            {
                List<RekoRing> ringList = new List<RekoRing>();
                ringList.Add(new RekoRing("Göteborg"));
                ringList.Add(new RekoRing("Borås"));
                ringList.Add(new RekoRing("Partille"));
                ringList.Add(new RekoRing("Stenungsund"));
                ringList.Add(new RekoRing("Mölndal"));
                ringList.Add(new RekoRing("Hästveda"));

                ringList.ForEach(RekoRing => DatabaseFacade.Instance.AddRekoRing(RekoRing));
             }

        }

        private void PopulateUsers()
        {
            List<User> checkList = DatabaseFacade.Instance.GetUsers();

            if (!checkList.Any())
            {
                List<User> userList = new List<User>();
                userList.Add(new User("Namorb", "pw"));
                userList.Add(new User("Fripperian", "pw"));
                userList.Add(new User("NictheStudent", "pw"));
                userList.Add(new User("FornMaria", "pw"));
                userList.Add(new User("oscgro19", "pw"));
                userList.Add(new User("ssamuelandersson", "pw"));
                userList.Add(new User("LucasAndren", "pw"));


                userList.ForEach(User => DatabaseFacade.Instance.AddUser(User));
            }

        }
    }
}
