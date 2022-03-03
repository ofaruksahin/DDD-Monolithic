namespace EShop.Domain.Events
{
    public class CustomerStatusChangedToPassiveDomainEvent : INotification
    {
        public Customer Customer { get; private set; }

        public CustomerStatusChangedToPassiveDomainEvent(Customer customer)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }
    }
}

