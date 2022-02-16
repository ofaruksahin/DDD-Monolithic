namespace EShop.Application.DomainEventHandlers.ProductEventHandlers
{
    public class ProductCreatedDomainEventHandler : INotificationHandler<ProductCreatedDomainEvent>
    {
        public async Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

        }
    }
}

