using System;

namespace EShop.Application.DomainEventHandlers.SellerEventHandlers
{
    public class SellerStatusChangedToPassiveDomainEventHandler : INotificationHandler<SellerStatusChangedToPassive>
    {
        public async Task Handle(SellerStatusChangedToPassive notification, CancellationToken cancellationToken)
        {

        }
    }
}

