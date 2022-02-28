namespace EShop.Application.DomainEventHandlers.CustomerEventHandlers
{
    public class CustomerAddressCreatedDomainEventHandler : INotificationHandler<CustomerAddressCreatedDomainEvent>
    {
        public async Task Handle(CustomerAddressCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

        }
    }
}

