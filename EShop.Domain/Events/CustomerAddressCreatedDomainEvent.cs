namespace EShop.Domain.Events
{
    public class CustomerAddressCreatedDomainEvent : INotification
    {
        public CustomerAddress CustomerAddress { get; private set; }

        public CustomerAddressCreatedDomainEvent(CustomerAddress customerAddress)
        {
            CustomerAddress = customerAddress ?? throw new ArgumentNullException(nameof(customerAddress));
        }
    }
}

