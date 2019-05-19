namespace REKO
{
    internal class DetailedOrder : OfferDetailed
    {
        private Order selected;

        public DetailedOrder(Order selected)
        {
            this.selected = selected;
        }
    }
}