namespace EShop.Application.DomainEventHandlers.ProductEventHandlers;

public class ProductStatusChangedToPassiveDomainEventHandler : INotificationHandler<ProductStatusChangedToPassiveDomainEvent>
{
    public async Task Handle(ProductStatusChangedToPassiveDomainEvent notification, CancellationToken cancellationToken)
    {

    }
}

