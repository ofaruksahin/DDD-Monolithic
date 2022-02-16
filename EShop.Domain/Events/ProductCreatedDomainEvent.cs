namespace EShop.Domain.Events
{
    public class ProductCreatedDomainEvent : INotification
    {
        public Product Product { get; set; }

        public ProductCreatedDomainEvent(Product product)
        {
            Product = product;
        }
    }
}

