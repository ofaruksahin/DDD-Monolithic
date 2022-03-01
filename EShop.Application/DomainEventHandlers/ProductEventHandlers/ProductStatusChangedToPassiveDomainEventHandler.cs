namespace EShop.Application.DomainEventHandlers.ProductEventHandlers;

public class ProductStatusChangedToPassiveDomainEventHandler : INotificationHandler<ProductStatusChangedToPassive>
{
    public async Task Handle(ProductStatusChangedToPassive notification, CancellationToken cancellationToken)
    {

    }
}

