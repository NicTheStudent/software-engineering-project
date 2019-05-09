using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace REKO
{
    public class DatabaseFacade
    {
        // SÅ HÄR SER DU DATABASEN
        // steg 1: ladda ner mongodb compass https://www.mongodb.com/products/compass
        // steg 2: kopiera följande mongodb+srv://RekoUser:<password>@rekodb-fhi6h.gcp.mongodb.net/test
        // steg 3: öppna mongodb compass, den kommer säga "vill du öppna med lönken du har kopierat"
        // steg 4: klicka ja
        // steg 5: fyll i lådan "password" med "pw"
        // steg 6: klicka på connect

        MongoClient client;
        IMongoDatabase db;

        List<Offer> offerList = new List<Offer>(); // tillhör stenåldern

        public DatabaseFacade()
        {
            client = new MongoClient("mongodb+srv://RekoUser:pw@rekodb-fhi6h.gcp.mongodb.net/test?retryWrites=true");
            db = client.GetDatabase("RekoDB");

            // kvar för att inte förstöra något gammalt
            offerList.Add(new Offer("Eggberts Ägg", 40, "E.L. Eggbert", 144, 0, "dussin", true));
            offerList.Add(new Offer("Bertils betor", 10, "Bertil Knutsson", 20, 0, "kg", true));
            offerList.Add(new Offer("Grönqvists gröna gurkor", 30, "Oskar Grönqvist", 15, 0, "st.", true));
            offerList.Add(new Offer("Marias margarin", 50, "Maria", 1000, 0, "g", true));
            offerList.Add(new Offer("Hampus & Sampas hampa", 50, "Hampus & Samuel", 300, 0, "g", true));

        }

        //returns all users
        public List<User> GetUsers()
        {
            return GetUsersFiltered(new FilterDefinitionBuilder<User>().Empty);
        }

        //returns users according to FilterDefinition, use FilterDefinitionBuilder
        public List<User> GetUsersFiltered(FilterDefinition<User> filter)
        {
            List<User> userList = new List<User>();
            var collection = db.GetCollection<User>("User");
            collection.FindSync(filter).ForEachAsync(User => userList.Add(User));
            return userList;
        }


        //returns all offers
        public List<Offer> GetOffers()
        {
            return GetOffersFiltered(new FilterDefinitionBuilder<Offer>().Empty);
        }



        //returns offers according to FilterDefinition, use FilterDefinitionBuilder
        public List<Offer> GetOffersFiltered(FilterDefinition<Offer> filter)
        {
            List<Offer> offerList = new List<Offer>();
            var collection = db.GetCollection<Offer>("Offer");
            collection.FindSync(filter).ForEachAsync(Offer => offerList.Add(Offer));
            return offerList;
        }

        //returns all rekorings
        public List<RekoRing> GetRekoRings()
        {
            FilterDefinition<RekoRing> filter = new FilterDefinitionBuilder<RekoRing>().Empty;
            List<RekoRing> ringList = new List<RekoRing>();
            var collection = db.GetCollection<RekoRing>("RekoRing");
            collection.FindSync(filter).ForEachAsync(RekoRing => ringList.Add(RekoRing));
            return ringList;
        }


        //doesnt work quite yet
        public List<T> getAnythingFiltered<T>(FilterDefinition<T> filter)
        {
            List<T> resultList = new List<T>();
            var collection = db.GetCollection<T>(typeof(T).ToString());
            collection.FindSync(filter).ForEachAsync(User => resultList.Add(User));
            return resultList;
        }

        // adds new user to database using many args
        public void AddUser(string first, string last, string email, int phone)
        {
            User newUser = new User
            {
                firstName = first,
                lastName = last,
                emailAdress = email,
                phoneNumber = phone
            };
            AddUser(newUser);
        }

        // adds new user to database, user id should be null.
        public void AddUser(User user)
        {
            var collection = db.GetCollection<User>("User");
            collection.InsertOne(user);
        }

        // adds new offer to database, offer id should be null.
        public void AddOffer(Offer offer)
        {
            var collection = db.GetCollection<Offer>("Offer");
            collection.InsertOne(offer);
        }
    }
}