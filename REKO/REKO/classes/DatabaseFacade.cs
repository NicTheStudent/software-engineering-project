using System;
using System.Collections.Generic;
//using Foundation;

namespace REKO
{
    public class DatabaseFacade
    {

        public List<Offer> OfferList = new List<Offer>();

        public DatabaseFacade()
        {
            OfferList.Add(new Offer("Eggberts Ägg", 40, "E.L. Eggbert", 144, 0, "dussin", true, 0));
            OfferList.Add(new Offer("Bertils betor", 10, "Bertil Knutsson", 20, 0, "kg", true, 1));
            OfferList.Add(new Offer("Grönqvists gröna gurkor", 30, "Oskar Grönqvist", 15, 0, "st.", true, 2));
            OfferList.Add(new Offer("Marias margarin", 50, "Maria", 1000, 0, "g", true, 3));
            OfferList.Add(new Offer("Hampus & Sampas hampa", 50, "Hampus & Samuel", 300, 0, "g", true, 4));
        }

    }
}