namespace EShop.Domain.Events
{
    public class SellerStatusChangedToPassive : INotification
    {
        public Seller Seller
        {
            get;
            private set;
        }

        public SellerStatusChangedToPassive(Seller seller)
        {
            Seller = seller;
        }
    }
}

