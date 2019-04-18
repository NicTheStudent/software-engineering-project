using System;
using System.Collections.Generic;
//using Foundation;

namespace REKO
{
    public class DatabaseFacade
    {

        List<Offer> offerList = new List<Offer>();

        public DatabaseFacade()
        {
            offerList.Add(new Offer("Eggberts Ägg", 40, "E.L. Eggbert", 144, 0, "dussin", true));
            offerList.Add(new Offer("Bertils betor", 10, "Bertil Knutsson", 20, 0, "kg", true));
            offerList.Add(new Offer("Grönqvists gröna gurkor", 30, "Oskar Grönqvist", 15, 0, "st.", true));
            offerList.Add(new Offer("Marias margarin", 50, "Maria", 1000, 0, "g", true));
            offerList.Add(new Offer("Hampus & Sampas hampa", 50, "Hampus & Samuel", 300, 0, "g", true));
        }

    }
}