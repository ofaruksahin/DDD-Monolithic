namespace EShop.Application.DomainEventHandlers.CustomerEventHandlers
{
    public class CustomerCreatedDomainEventHandler : INotificationHandler<CustomerCreatedDomainEvent>
    {
        public async Task Handle(CustomerCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
        }
    }
}

