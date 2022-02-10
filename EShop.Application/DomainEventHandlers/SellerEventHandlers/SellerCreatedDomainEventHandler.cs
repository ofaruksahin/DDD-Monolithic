namespace EShop.Application.DomainEventHandlers.SellerEventHandlers
{
    public class SellerCreatedDomainEventHandler : INotificationHandler<SellerCreatedDomainEvent>
    {
        public async Task Handle(SellerCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

        }
    }
}

