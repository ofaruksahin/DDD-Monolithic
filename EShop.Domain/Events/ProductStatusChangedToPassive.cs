namespace EShop.Domain.Events
{
    public class ProductStatusChangedToPassive : INotification
    {
        public Product Product { get; private set; }

        public ProductStatusChangedToPassive(Product product)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
        }
    }
}

