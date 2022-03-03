using System;

namespace EShop.Application.DomainEventHandlers.SellerEventHandlers
{
    public class SellerStatusChangedToPassiveDomainEventHandler : INotificationHandler<SellerStatusChangedToPassiveDomainEvent>
    {
        public async Task Handle(SellerStatusChangedToPassiveDomainEvent notification, CancellationToken cancellationToken)
        {

        }
    }
}

