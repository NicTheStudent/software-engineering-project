using System;
using System.Collections.Generic;
//using Foundation;

namespace REKO
{
    public class DatabaseFacade
    {

        public  List<Offer> offerList = new List<Offer>();
        public List<Producer> ProducerList= new List<Producer>();

        public DatabaseFacade()
        {
            offerList.Add(new Offer("Eggberts Ägg", 40, "E.L. Eggbert", 144, 0, "dussin", true));
            offerList.Add(new Offer("Bertils betor", 10, "Bertil Knutsson", 20, 0, "kg", true));
            offerList.Add(new Offer("Grönqvists gröna gurkor", 30, "Oskar Grönqvist", 15, 0, "st.", true));
            offerList.Add(new Offer("Marias margarin", 50, "Maria", 1000, 0, "g", true));
            offerList.Add(new Offer("Hampus & Sampas hampa", 50, "Hampus & Samuel", 300, 0, "g", true));

            ProducerList.Add(new Producer("Eggberts Ägg", "Jag har 800 hönor men är allergisk mot ägg, säljer därför av lite nu till påsk", 1337, "Göteborg"));
            ProducerList.Add(new Producer("Bertils Betor", "Säljer schyssta röd-, gul- och polkabetor", 241, "Göteborg"));
            ProducerList.Add(new Producer("Grönqvists gurkor", "Salta och söta", 42, "Göteborg"));
            ProducerList.Add(new Producer("Marias Margarin", "Perfekt för morgonmackan", 81, "Göteborg"));
            ProducerList.Add(new Producer("Hampas och Sampas hampa", "Hampa av högsta kvalle", 1, "Gävle"));
            ProducerList.Add(new Producer("Niclas Nikotin", "Mängdrabatt! Extrapris på limpor och stockar. Ciggen har jag rullat själv", 19, "Göteborg"));
            ProducerList.Add(new Producer("Lök-Lucas", "Röd-,gul-, vit- och silverlök. Fina priser!", 33, "Göteborg"));
            ProducerList.Add(new Producer("Freddans fisk", "Varmrökt och kallrökt sump-gädda", 80, "Göteborg" ));
        }

    }
}