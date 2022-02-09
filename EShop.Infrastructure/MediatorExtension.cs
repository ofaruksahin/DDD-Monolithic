namespace EShop.Infrastructure
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventasync(this IMediator mediator, EShopDbContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(f => f.Entity.DomainEvents != null && f.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(f => f.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList().ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }    
    }
}

