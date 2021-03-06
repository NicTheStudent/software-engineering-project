﻿using System;
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
            PopulateProducers();
            PopulateOffers();
            PopulateOrders();
        }

        private void PopulateRings()
        {
            List<RekoRing> checkList = DatabaseFacade.Instance.GetRekoRings();

            if (!checkList.Any())
            {
                List<RekoRing> ringList = new List<RekoRing>();
                ringList.Add(new RekoRing("Göteborg", new DateTime(2019,6,20,18,0,0)));
                ringList.Add(new RekoRing("Borås", new DateTime(2019,7,1,18,0,0)));

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

        private void PopulateProducers()
        {
            List<Producer> checkList = DatabaseFacade.Instance.GetProducers();


            if (!checkList.Any())
            {
                List<User> userList = DatabaseFacade.Instance.GetUsers();
                List<RekoRing> ringList = DatabaseFacade.Instance.GetRekoRings();

                List<Producer> producerList= new List<Producer>();
                producerList.Add(new Producer("Eggberts Äggfarm", "Jag har 800 hönor men är allergisk mot ägg, säljer därför av några inför sommaren", userList[0], ringList[0]));
                producerList.Add(new Producer("Bertils Betodling", "Säljer schyssta röd-, gul- och polkabetor", userList[1], ringList[0]));
                producerList.Add(new Producer("Grönqvists Gurkplantage", "Salta och söta", userList[2], ringList[0]));
                producerList.Add(new Producer("Marias Margarinfabrik", "Perfekt för morgonmackan", userList[3], ringList[0]));
                producerList.ForEach(Producer => DatabaseFacade.Instance.AddProducer(Producer));
            }
        }

        private void PopulateOffers()
        {
            List<Offer> checkList = DatabaseFacade.Instance.GetOffers();
            if (!checkList.Any())
            {
                List<Producer> producerList = DatabaseFacade.Instance.GetProducers();

                List<Offer> offerList = new List<Offer>();
                offerList.Add(new Offer("Eggberts Ägg", "Ägg", 20, producerList[0],144, 0, "dussin", true));
                offerList.Add(new Offer("Bertils Betor", "Betor", 10, producerList[1], 50, 0, "kg", true));
                offerList.Add(new Offer("Grönqvists gurkor", "Gurkor", 5, producerList[2], 100, 0, "st", true));
                offerList.Add(new Offer("Marias Margarin", "Margarin", 50, producerList[3], 25, 0, "pkt", true));
                offerList.ForEach(Offer => DatabaseFacade.Instance.AddOffer(Offer));

            }
        }

        private void PopulateOrders()
        {
            List<Order>checkList = DatabaseFacade.Instance.GetOrders();
            if (!checkList.Any())
            {
                List<User> userList = DatabaseFacade.Instance.GetUsers();
                List<Offer> offerList = DatabaseFacade.Instance.GetOffers();

                List<Order> orderList = new List<Order>();
                orderList.Add(new Order(userList[0], offerList[0], 1, 1, offerList[0].Seller.RekoRing.nextMeetup));
                orderList.Add(new Order(userList[1], offerList[1], 1, 3, offerList[1].Seller.RekoRing.nextMeetup));
                orderList.Add(new Order(userList[2], offerList[2], 1, 4, offerList[2].Seller.RekoRing.nextMeetup));
                orderList.Add(new Order(userList[3], offerList[3], 1, 10, offerList[3].Seller.RekoRing.nextMeetup));
                orderList.Add(new Order(userList[4], offerList[0], 1, 5, offerList[0].Seller.RekoRing.nextMeetup));

                //Adding older orders
                orderList.Add(new Order(userList[6], offerList[0], 1, 2, new DateTime(1997,2,23,22,9,0)));
                orderList.Add(new Order(userList[6], offerList[1], 1, 3, new DateTime(2019,4,25,18,0,0)));

                orderList.ForEach(Order => DatabaseFacade.Instance.AddOrder(Order));
            }
        }
    }
}
