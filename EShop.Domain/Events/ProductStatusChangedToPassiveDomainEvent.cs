namespace EShop.Domain.Events
{
    public class ProductStatusChangedToPassiveDomainEvent : INotification
    {
        public Product Product { get; private set; }

        public ProductStatusChangedToPassiveDomainEvent(Product product)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
        }
    }
}

