namespace EShop.Domain.Events
{
    public class OrderCreatedDomainEvent : INotification
    {
        public Order Order { get; private set; }

        public OrderCreatedDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
