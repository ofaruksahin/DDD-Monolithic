namespace EShop.Domain.Events
{
    public class BasketAddedItemDomainEvent : INotification
    {
        public BasketItem BasketItem { get; private set; }

        public BasketAddedItemDomainEvent(BasketItem basketItem)
        {
            BasketItem = basketItem;
        }
    }
}

