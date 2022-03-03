namespace EShop.Application.DomainEventHandlers.CustomerEventHandlers
{
    public class CustomerStatusChangedToPassiveDomainEventHandler : INotificationHandler<CustomerStatusChangedToPassiveDomainEvent>
    {
        public async Task Handle(CustomerStatusChangedToPassiveDomainEvent notification, CancellationToken cancellationToken)
        {
        }
    }
}

