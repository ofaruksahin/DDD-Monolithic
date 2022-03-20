namespace EShop.Application.DomainEventHandlers.OrderEventHandlers
{
    public class OrderCreatedDomainEventHandler : INotificationHandler<OrderCreatedDomainEvent>
    {
        public async Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
        }
    }
}
