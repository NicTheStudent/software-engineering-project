using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;

namespace REKO
{
    public sealed class DatabaseFacade
    {
        //Singleton class that does all communication with database.

        // SÅ HÄR SER DU DATABASEN (GAMMALT, VI ANVÄNDER NU LOKAL DATABASSERVER)
        // steg 1: ladda ner mongodb compass https://www.mongodb.com/products/compass
        // steg 2: kopiera följande mongodb+srv://RekoUser:<password>@rekodb-fhi6h.gcp.mongodb.net/test
        // steg 3: öppna mongodb compass, den kommer säga "vill du öppna med lönken du har kopierat"
        // steg 4: klicka ja
        // steg 5: fyll i lådan "password" med "pw"
        // steg 6: klicka på connect


        public  List<Offer> offerList = new List<Offer>();
        public List<Producer> ProducerList= new List<Producer>();

        private static readonly DatabaseFacade INSTANCE = new DatabaseFacade();

        MongoClient client;
        IMongoDatabase db;

        public static DatabaseFacade Instance
        {
            get
            {
                return INSTANCE;
            }
        }

        private DatabaseFacade()
        {
            try
            {
                client = new MongoClient("mongodb://10.0.2.2:27017");  // "mongodb://localhost:27017" "mongodb+srv://RekoUser:pw@rekodb-fhi6h.gcp.mongodb.net/test?retryWrites=true"
            }
            catch (AggregateException e)
            {
                System.Diagnostics.Debug.WriteLine("THE EXCPETION" + e.ToString());
            }
           
           db = client.GetDatabase("RekoDB");



            User u1 = new User("Namorb", "pw");
            User u2 = new User("Fripperian", "pw");
            User u3 = new User("NictheStudent", "pw");
            User u4 = new User("FornMaria", "pw");
            User u5 = new User("oscgro19", "pw");
            User u6 = new User("ssamuelandersson", "pw");
            User u7 = new User("LucasAndren", "pw");

            RekoRing r1 = new RekoRing("Göteborg");

            Producer p1 = new Producer("Eggberts Ägg", "Jag har 800 hönor men är allergisk mot ägg, säljer därför av lite nu till påsk", u1, r1);
            Producer p2 = new Producer("Bertils Betor", "Säljer schyssta röd-, gul- och polkabetor", u2, r1);
            Producer p3 = new Producer("Grönqvists gurkor", "Salta och söta", u3, r1);
            Producer p4 = new Producer("Marias Margarin", "Perfekt för morgonmackan", u4, r1);

            ProducerList.Add(p1);
            ProducerList.Add(p2);
            ProducerList.Add(p3);
            ProducerList.Add(p4);

            // kvar för att inte förstöra något gammalt
            offerList.Add(new Offer("Eggberts Ägg", "ägg", 40, p1, 144, 0, "dussin", true));
            offerList.Add(new Offer("Bertils betor", "betor", 10, p2, 20, 0, "kg", true));
            offerList.Add(new Offer("Grönqvists gröna gurkor", "gurka", 30, p3, 15, 0, "st.", true));
            offerList.Add(new Offer("Marias margarin", "margarin", 50, p4, 1000, 0, "g", true));




        }

        //** METHODS RELATING TO CLASS: User **

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
        //checks if a username i already taken
        public Boolean CheckUsernameExists(string username)
        {
            var userList = GetUsersFiltered(new FilterDefinitionBuilder<User>().Eq(User => User.username, username));
            if (userList.Any())
                return true;
            else
                return false;
        }

        //** METHODS RELATING TO CLASS: Producer **

        public void AddProducer(Producer producer)
        {
            var collection = db.GetCollection<Producer>("Producer");
            collection.InsertOne(producer);
        }

        public List<Producer> GetProducers()
        {
            return GetProducersFiltered(new FilterDefinitionBuilder<Producer>().Empty);
        }

        public List<Producer> GetProducers(User user)
        {
            return GetProducersFiltered(new FilterDefinitionBuilder<Producer>().Eq(Producer => Producer.user, user));
        }


        //returns offers according to FilterDefinition, use FilterDefinitionBuilder
        public List<Producer> GetProducersFiltered(FilterDefinition<Producer> filter)
        {
            List<Producer> producerList = new List<Producer>();
            var collection = db.GetCollection<Producer>("Producer");
            collection.FindSync(filter).ForEachAsync(Producer => producerList.Add(Producer));
            return producerList;
        }


        //** METHODS RELATING TO CLASS: Offer **


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

        public List<Offer> GetOffers(Producer producer)
        {
            return GetOffersFiltered(new FilterDefinitionBuilder<Offer>().Eq(Offer => Offer.Seller, producer));
        }


        //returns all orders
        public List<Order> GetOrders()
        {
            return GetOrdersFiltered(new FilterDefinitionBuilder<Order>().Empty);
        }


        //return orders filtered on buyer
        public List<Order> GetOrders(User user)
        {
            var filter = new FilterDefinitionBuilder<Order>().Eq(Order => Order.User, user);
            return GetOrdersFiltered(filter);
        }

        //returns orders according to FilterDefinition, use FilterDefinitionBuilder
        public List<Order> GetOrdersFiltered(FilterDefinition<Order> filter)
        {
            List<Order> orderList = new List<Order>();
            var collection = db.GetCollection<Order>("Order");
            collection.FindSync(filter).ForEachAsync(Order => orderList.Add(Order));
            return orderList;
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

        public void AddRekoRing(RekoRing rekoring)
        {
            var collection = db.GetCollection<RekoRing>("RekoRing");
            collection.InsertOne(rekoring);
        }

        //doesnt work quite yet
        public List<T> getAnythingFiltered<T>(FilterDefinition<T> filter)
        {
            List<T> resultList = new List<T>();
            var collection = db.GetCollection<T>(typeof(T).ToString());
            collection.FindSync(filter).ForEachAsync(User => resultList.Add(User));
            return resultList;
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

        //adds a new order to the database, order id should be null
        public void AddOrder(Order order)
        {
            var collection = db.GetCollection<Order>("Order");
            collection.InsertOne(order);
        }

        public void RemoveOrder(Order order)
        {
            var collection = db.GetCollection<Order>("Order");
            var filter = new FilterDefinitionBuilder<Order>().Eq(Order => Order.id, order.id);
            collection.DeleteOne(filter);
        }
    }
}