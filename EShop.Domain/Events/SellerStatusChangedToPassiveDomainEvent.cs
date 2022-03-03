namespace EShop.Domain.Events
{
    public class SellerStatusChangedToPassiveDomainEvent : INotification
    {
        public Seller Seller
        {
            get;
            private set;
        }

        public SellerStatusChangedToPassiveDomainEvent(Seller seller)
        {
            Seller = seller;
        }
    }
}

