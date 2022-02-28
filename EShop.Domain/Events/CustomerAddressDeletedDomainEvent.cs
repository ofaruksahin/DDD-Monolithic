namespace EShop.Domain.Events
{
    public class CustomerAddressDeletedDomainEvent : INotification
    {
        public CustomerAddress customerAddress { get; private set; }

        public CustomerAddressDeletedDomainEvent(CustomerAddress customerAddress)
        {
            this.customerAddress = customerAddress ?? throw new ArgumentNullException(nameof(customerAddress));
        }
    }
}

