namespace EShop.Application.DomainEventHandlers.BasketEventHandlers
{
    public class BasketAddedItemDomainEventHandler : INotificationHandler<BasketAddedItemDomainEvent>
    {
        public async Task Handle(BasketAddedItemDomainEvent notification, CancellationToken cancellationToken)
        {
        }
    }
}

