using System;
namespace REKO
{
    public class Offer
    {

        String name, seller, unit;
        double price;
        int available, ordered;
        bool published;

        public Offer(String name, double price, String seller, int available, int ordered, String unit, bool published)
        {
            this.name = name;
            this.price = price;
            this.seller = seller;
            this.available = available;
            this.ordered = ordered;
            this.unit = unit;
            this.published = published;
        }

        public String GetName()
        {
            return name;
        }
        public double GetPrice()
        {
            return price;
        }
        public String GetPriceString()
        {
            return String.Format("{0:F2}", price);
        }
        public String GetSeller()
        {
            return seller;
        }
        public int GetAvailable()
        {
            return available;
        }
        public int GetOrdered()
        {
            return ordered;
        }
        public String GetUnit()
        {
            return unit;
        }
        public bool GetPublished()
        {
            return published;
        }

        //----------------------------------



    }
}
