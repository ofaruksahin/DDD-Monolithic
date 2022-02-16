namespace EShop.Domain.AggregatesModel.ProductAggregateModel
{
    public class Product : Entity, IAggregateRoot
    {
        public ProductSeller ProductSeller { get; private set; }
        public int SellerId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }
        public int CategoryId { get; set; }

        private readonly List<ProductAttribute> _attributes;
        public IReadOnlyList<ProductAttribute> Attributes => _attributes;

        protected Product()
        {
            _attributes = new List<ProductAttribute>();
        }

        public Product(
            string name,
            string description,
            int quantity,
            double price,
            int sellerId,
            int categoryId,
            List<ProductAttribute> attributes = default)
        {
            _attributes = new List<ProductAttribute>();

            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
            SellerId = sellerId;
            CategoryId = categoryId;

            if (attributes != null)
            {
                attributes.ForEach(item => _attributes.Add(item));
            }

            _statusId = EnumStatus.Active.Id;
            AddDomainEvent(new ProductCreatedDomainEvent(this));
        }
    }
}