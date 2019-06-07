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
using System.Security.Authentication;

namespace REKO
{
    public sealed class DatabaseFacade
    {
        //Singleton class that does all communication with database.

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
                string connectionString = @"mongodb://rekoadmin:PGM8IEyhVIYkzlQnO1lIt6hW2hLdswWcJ9v9MKPwoEE3RnHvzGmDaZAwMEz7OdKwWnEApgSgkwsDVx4OwwdpMA==@rekoadmin.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                client = new MongoClient(settings);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("DB CONNECTION ERROR");
            }
           
           db = client.GetDatabase("RekoDB");

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

        //Returns all Orders on an Offer
        public List<Order> GetOrders(Offer offer)
        {
            var filter = new FilterDefinitionBuilder<Order>().Eq(Order => Order.Offer.Id, offer.Id);
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

        public List<Order> GetCurrentOrders(User user)
        {
            List<Order> orderList = new List<Order>();
            var collection = db.GetCollection<Order>("Order");
            var filterTime = new FilterDefinitionBuilder<Order>().Gt(Order => Order.TimeSold, DateTime.Now);
            var filterUser = new FilterDefinitionBuilder<Order>().Eq(Order => Order.User, user);
            var filter = filterTime & filterUser;
            collection.FindSync(filter).ForEachAsync(Order => orderList.Add(Order));
            return orderList;
        }

        //returns all orders that belong to a user and are no longer active
        public List<Order> GetOldOrders(User user)
        {
            List<Order> orderList = new List<Order>();
            var collection = db.GetCollection<Order>("Order");
            var filterTime = new FilterDefinitionBuilder<Order>().Lt(Order => Order.TimeSold, DateTime.Now);
            var filterUser = new FilterDefinitionBuilder<Order>().Eq(Order => Order.User, user);
            var filter = filterTime & filterUser;
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

        public void RemoveOffer(Offer offer)
        {
            var collection = db.GetCollection<Offer>("Offer");
            var filter = new FilterDefinitionBuilder<Offer>().Eq(Offer => Offer.Id, offer.Id);
            collection.DeleteOne(filter);
        }

        public void UpdateOfferAmount(Offer offer)
        {
            var collection = db.GetCollection<Offer>("Offer");
            var filter = new FilterDefinitionBuilder<Offer>().Eq(Offer => Offer.Id, offer.Id);
            var update = new UpdateDefinitionBuilder<Offer>().Set(Offer => Offer.CurrentAmount, offer.CurrentAmount);
            collection.UpdateOne(filter, update);
        }

        public void RemoveData()
        {
            db.DropCollection("Offer");
            db.DropCollection("Order");
            db.DropCollection("User");
            db.DropCollection("RekoRing");
            db.DropCollection("Producer");
        }
    }
}